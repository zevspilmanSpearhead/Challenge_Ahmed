export default function Table({ data }) {
  //get all the headers
  const tableHeaders = Object.keys(data[0]);
  return (
    <table className="table-auto min-w-full bg-white border border-gray-300 rounded-md overflow-hidden">
      <thead>
        <tr className="bg-gray-200">
          {tableHeaders.map((header) => {
            return (
              <th key={header} className="py-2 px-4">
                {header}
              </th>
            );
          })}
        </tr>
      </thead>
      <tbody>
        {data.map((data, index) => {
          return (
            <tr key={index} className="hover:bg-gray-50">
              {tableHeaders.map((header, index) => {
                return (
                  <td key={index} className="py-2 px-4">
                    {data[header]}
                  </td>
                );
              })}
            </tr>
          );
        })}
      </tbody>
    </table>
  );
}
