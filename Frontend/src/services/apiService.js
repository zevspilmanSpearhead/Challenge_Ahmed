// apiService.js
import axios from 'axios';

const API_BASE_URL = 'https://localhost:44357/api'; // Replace with your API base URL

const apiService = {
  getInvoices: async (accessToken) => {
    try {
      const response = await axios.get(`${API_BASE_URL}/Invoices`,{
        headers:{
            Authorization: `Bearer ${accessToken}`,
            // Add other headers as needed
        }
      });
      return response.data;
    } catch (error) {
      console.error('Error fetching invoices:', error);
      throw error;
    }
  }
};

export default apiService;
