import React, { useEffect, useState } from "react";
import { fetchData } from "../services/apiService";

const Result = () => {
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchApiData = async () => {
      try {
        const result = await fetchData("/your-endpoint");
        setData(result);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchApiData();
  }, []);

  return (
    <div>
      <h1 className="text-3xl font-bold underline text-center bg-stone-600">Hello world!</h1>
      {/* Render your component using the fetched data */}
      {data.map((item) => (
        <div key={item.id}>{item.name}</div>
      ))}
    </div>
  );
};

export default Result;
