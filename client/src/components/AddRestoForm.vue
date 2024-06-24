<template>
  <div class="bg-neutral-100 mt-3 md:p-8 xs:p-6 basis-1/3 md:mr-5 rounded-md">
    <form @submit="handleSubmit">
      <div class="mb-4">
        <label for="restoName" class="block text-gray-700 mb-1 font-semibold">Name:</label>
        <input type="text" id="restoName" v-model="newResto.Resto" class="w-full bg-gray-100 border border-gray-300 rounded-sm px-2 py-1 focus:outline-none focus:ring-1 shadow-md" required>
      </div>
      <div class="mb-4 flex space-x-4">
        <div class="flex-1">
          <label for="restoType" class="block text-gray-700 mb-1 font-semibold">Type:</label>
          <select id="restoType" v-model="newResto.Type" class="w-full bg-gray-100 border border-gray-300 rounded-sm px-2 py-1 focus:outline-none focus:ring-1 shadow-md" required>
            <option>Meal</option>
            <option>Snack</option>
            <option>Dessert</option>
          </select>
        </div>
        <div class="flex flex-col items-start">
          <label for="restoIsVisited" class="block text-gray-700 mb-1 font-semibold">Visited?</label>
          <input type="checkbox" id="restoIsVisited" v-model="newResto.IsVisited" class="bg-gray-100 mt-2 ml-5 focus:outline-none focus:ring-1 transform scale-150">
        </div>
      </div>
      <div class="mb-4">
        <label for="restoDescription" class="block text-gray-700 mb-1 font-semibold">Description:</label>
        <textarea id="restoDescription" v-model="newResto.Description" class="w-full shadow-md bg-gray-100 border border-gray-300 rounded-sm px-2 py-1 focus:outline-none focus:ring-1" required></textarea>
      </div>
      <button type="submit" class="w-full bg-[#f9c97e] text-[#0e1420] rounded-md px-4 py-2 font-semibold hover:bg-orange-300 focus:outline-none focus:bg-orange-400 
      md:text-xl font-[cambria] shadow-md">Add Restaurant</button>
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
  