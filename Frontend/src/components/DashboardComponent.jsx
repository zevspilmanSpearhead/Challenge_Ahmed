import React, { useEffect, useState } from "react";
import apiService from "../services/apiService";
import Table from "./Table";

const DashboardComponent = () => {
  const [invoices, setInvoices] = useState([]);

  useEffect(() => {
    // Extract the access token from the URL query parameters
    const urlParams = new URLSearchParams(window.location.search);
    const accessToken = urlParams.get("access_token");
    if (accessToken) {
      const fetchInvoices = async () => {
        try {
          const response = await apiService.getInvoices(accessToken);
          console.log("response", response);
          setInvoices(response);
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
    <>
      <div className="flex flex-col items-center justify-center min-h-screen">
        <h1 className="text-4xl font-bold mb-8 text-gray-800">Dashboard</h1>
        <div className="bg-gray-100 p-8 rounded-md shadow-md">
          {invoices.length > 0 && <Table data={invoices} />}
        </div>
      </div>
    </>
  );
};

export default DashboardComponent;
