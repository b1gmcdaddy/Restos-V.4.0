<template>
    <div class="bg-white mt-5 p-5 basis-1/3 md:mr-5 max-h-72">
      <form @submit="handleSubmit">
        <div>
          <label for="restoName">Name:</label>
          <input type="text" id="restoName" v-model="newResto.Resto" class="bg-gray-100 border border-gray-300 rounded-sm px-2 mb-4 focus:outline-none focus:ring-1" required>
        </div>
        <div>
          <label for="restoType">Type:</label>
          <select id="restoType" v-model="newResto.Type" class="bg-gray-100 border border-gray-300 rounded-sm px-2 mb-4 focus:outline-none focus:ring-1" required>
              <option>Meal</option>
              <option>Snack</option>
              <option>Dessert</option>
          </select>
        </div>
        <div>
          <label for="restoDescription">Description:</label>
          <textarea id="restoDescription" v-model="newResto.Description" class="bg-gray-100 border border-gray-300 rounded-sm px-2 mb-4 focus:outline-none focus:ring-1" required></textarea>
        </div>
        <div>
          <label for="restoIsVisited">Visited?</label>
          <input type="checkbox" id="restoIsVisited" v-model="newResto.IsVisited" class="bg-gray-100 border border-gray-300 rounded-sm px-2 mb-4 focus:outline-none focus:ring-1">
        </div>
        <button type="submit" class="w-full bg-green-800 text-white rounded-md px-4 py-2 font-semibold hover:bg-green-600 focus:outline-none focus:bg-green-600">Add Restaurant</button>
      </form>
    </div>
  </template>
  
  <script>
  import api from '../services/api.js';
  
  export default {
    name: 'AddRestoForm',
    data() {
      return {
        newResto: {
          Resto: '',
          Type: 'Meal',
          Description: '',
          IsVisited: false
        }
      };
    },
    methods: {
      handleSubmit() {
        api.addResto(this.newResto)
          .then(() => {
            alert('Restaurant added successfully!');
            this.resetForm();
          })
          .catch(error => {
            console.error('Error adding restaurant:', error);
            alert('Failed to add restaurant. Please try again.');
          });
      },
      resetForm() {
        this.newResto = {
          Resto: '',
          Type: 'Meal',
          Description: '',
          IsVisited: false
        };
      }
    }
  };
  </script>
  