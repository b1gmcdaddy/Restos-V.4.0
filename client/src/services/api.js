import axios from 'axios';

const API_URL = 'http://localhost:5148/api/Resto';

export default {

  getAllRestos() {
    return axios.get(API_URL)
      .then(response => response.data)
      .catch(error => {
        console.error('Error fetching restaurants:', error);
        throw error;
      });
  },


  getRestoById(id) {
    return axios.get(`${API_URL}/${id}`)
      .then(response => response.data)
      .catch(error => {
        console.error(`Error fetching restaurant with ID ${id}:`, error);
        throw error;
      });
  },


  addResto(resto) {
    return axios.post(API_URL, resto)
      .then(response => response.data)
      .catch(error => {
        console.error('Error adding restaurant:', error);
        throw error;
      });
  },


  editResto(id, resto) {
    return axios.put(`${API_URL}/${id}`, resto)
      .then(response => response.data)
      .catch(error => {
        console.error(`Error updating restaurant with ID ${id}:`, error);
        throw error;
      });
  },


  deleteResto(id) {
    return axios.delete(`${API_URL}/${id}`)
      .then(response => response.data)
      .catch(error => {
        console.error(`Error deleting restaurant with ID ${id}:`, error);
        throw error;
      });
  }
};
