import React, { useEffect, useState } from "react";
import apiService from "../services/apiService";

const DashboardComponent = () => {
  const [invoices, setInvoices] = useState([]);

  useEffect(() => {
    // Extract the access token from the URL query parameters
    const urlParams = new URLSearchParams(window.location.search);
    const accessToken = urlParams.get("access_token");
    if (accessToken) {
      const fetchInvoices = async () => {
        try {
          const { response } = await apiService.getInvoices(accessToken);
          console.log("response", response);
          setInvoices(response?.result?.invoice);
        } catch (error) {
          console.log(error);
        }
      };

      fetchInvoices();
    } else {
      console.error("Access token not found in the URL");
    }
  }, []);
  return (
    <div>
      <h1>Dashboard</h1>
      <table className="table-auto">
        <thead>
          <tr>
            <th className="px-4 py-2">Column 1</th>
            <th className="px-4 py-2">Column 2</th>
            {/* Add more columns as needed */}
          </tr>
        </thead>
        <tbody>
          {invoices &&
            invoices.map((item) => (
              <tr key={item.id}>
                <td className="border px-4 py-2">{item.column1}</td>
                <td className="border px-4 py-2">{item.column2}</td>
                {/* Add more cells as needed */}
              </tr>
            ))}
        </tbody>
      </table>
    </div>
  );
};

export default DashboardComponent;
