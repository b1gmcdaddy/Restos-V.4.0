<template>
  <div class="background-container">
    <Banner />
    <div class="md:flex flex-row mx-auto w-[80%]">
      <!-- FORM TO ADD RESTOS -->
      <AddRestoForm />

      <div class="bg-white md:flex mt-5 basis-2/3 max-h-[40vh] overflow-y-auto">
        <!------ List of VISITED Restos  ------>
        <ul v-if="showVisitedRestos">
          <li v-for="resto in visitedRestos" :key="resto.id" class="p-2">
            <h2 class="font-bold">{{ resto.resto }}</h2>
            <p>{{ resto.description }}</p>
            <p>Type: {{ resto.type }}</p>
            <p>Rating: {{ resto.rating }}</p>
            <p>Status: {{ resto.isVisited ? 'Visited' : 'Not Visited' }}</p>
            <button @click="deleteResto(resto.id)">Delete</button>
          </li>
        </ul>
        <!------ List of NOT Visited Restos  ------>
        <ul v-else>
          <li v-for="resto in notVisitedRestos" :key="resto.id" class="p-2">
            <h2 class="font-bold">{{ resto.resto }}</h2>
            <p>{{ resto.description }}</p>
            <p>Type: {{ resto.type }}</p>
            <p>Status: {{ resto.isVisited ? 'Visited' : 'Not Visited' }}</p>
            <button @click="markAsVisited(resto)">DONE</button>
            <input type="number" v-model="resto.rating" placeholder="Rating" min="1" max="5">
            <button @click="deleteResto(resto.id)">Delete</button>
          </li>
        </ul>
        <button @click="showNotVisited">Restos To Go</button>&nbsp;&nbsp;
        <button @click="showVisited">Done</button>
      </div>
    </div>
  </div>
</template>


<script>
import AddRestoForm from './components/AddRestoForm.vue';
import Banner from './components/Banner.vue';
import api from './services/api.js';

export default {
  name: 'App',
  components: {
    AddRestoForm, Banner
  },
  data() {
    return {
      restos: [],
      showVisitedRestos: false
    };
  },
  computed: {
    visitedRestos() {
      return this.restos.filter(resto => resto.isVisited);
    },
    notVisitedRestos() {
      return this.restos.filter(resto => !resto.isVisited);
    }
  },
  mounted() {
    this.fetchRestos();
  },
  methods: {
    fetchRestos() {
      api.getAllRestos()
        .then(data => {
          this.restos = data;
        })
        .catch(error => {
          console.error('Error fetching restoss:', error);
        });
    },

    showNotVisited() {
      this.showVisitedRestos = false;
    },

    showVisited() {
      this.showVisitedRestos = true;
    },

    deleteResto(id) {
      if(confirm('Are you sure you want to delete this restaurant?')) {
        api.deleteResto(id)
          .then(() => {
            this.fetchRestos();
          })
          .catch(error => {
            console.error('Error deleting restaurant:', error);
            alert('Failed to delete restaurant. Please try again.');
          });
      }
    },

    markAsVisited(resto) {
      if (resto.rating < 1 || resto.rating > 5) {
        alert('Please enter a valid rating (1-5).');
        return;
      }
      resto.isVisited = true;
      api.editResto(resto.id, resto)
        .then(() => {
          this.fetchRestos();
        })
        .catch(error => {
          console.error('Error marking restaurant as visited:', error);
          alert('Failed to mark restaurant as visited. Please try again.');
        });
    },
  }
};
</script>



<style>
html, body {
  margin: 0;
  padding: 0;
}
</style>

<style scoped>
.background-container {
  position: fixed;
  width: 100%;
  height: 100vh;
  background-image: url('@/assets/bg-image.jpg');
  background-size: cover;
  background-position: center;
}
</style>
