<template>
  <div class="background-container">
    <Banner />
    <div class="md:flex flex-row mx-auto w-[80%] ">
      <!-- FORM TO ADD RESTOS -->
      <AddRestoForm />

      <div class="mt-3 basis-2/3 overflow-y-auto rounded-md bg-neutral-100 xs:max-h-[50vh]">
        
        <div class="flex items-center justify-between mx-6 my-3">
          <h2 class="text-xl font-bold font-[tahoma]">
              {{ showVisitedRestos ? 'Visited' : 'Restos To Go' }}
          </h2>
          <select @change="handleSelectChange" class="border-[1.5px] p-2 shadow-md hover:bg-neutral-50">
            <option value="notVisited">Restos To Go</option>
            <option value="visited">Visited</option>
          </select>
         </div>
        <!------ List of VISITED Restos  ------>
        <ul v-if="showVisitedRestos">
          <li v-for="resto in visitedRestos" :key="resto.id" class="shadow-xl flex flex-col p-6 my-2 mx-6 rounded-lg">
            <div class="md:flex justify-between">
              <h2 class="font-bold text-xl">{{ resto.resto }}</h2>
              <div class="">
                <button @click="deleteResto(resto.id)"><font-awesome-icon icon="trash" class="text-2xl text-red-800 hover:scale-125 duration-150" /></button>
              </div>
            </div>
            <p>{{ resto.description }}</p>
            <p>Type: {{ resto.type }}</p>
            <p>Rating: {{ resto.rating }}</p>
          </li>
        </ul>
        <!------ List of NOT Visited Restos  ------>
        <ul v-else>
          <li v-for="resto in notVisitedRestos" :key="resto.id" class="shadow-xl flex flex-col p-6 my-2 mx-6 rounded-lg">
            <div class="md:flex justify-between">
              <h2 class="font-bold text-xl">{{ resto.resto }}</h2>
              <div class="">
                <button @click="markAsVisited(resto)"><font-awesome-icon icon="check" class="text-2xl text-[#0e1420] hover:scale-125 duration-150" /></button>
                <button @click="deleteResto(resto.id)"><font-awesome-icon icon="trash" class="text-2xl text-red-800 hover:scale-125 duration-150 md:ml-5" /></button>
              </div>
            </div>
            <p>{{ resto.description }}</p>
            <p>Type: {{ resto.type }}</p>
        
            <div class="flex">
            <p class="mr-3">Rating: </p>
            <input type="number" v-model="resto.rating" min="1" max="5" class="w-14 rounded-sm border-2">
          </div>
          </li>
        </ul>
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

    handleSelectChange(e) {
      const selectedOption = e.target.value;
      if (selectedOption === 'visited') {
        this.showVisitedRestos = true;
      } else if (selectedOption === 'notVisited') {
        this.showVisitedRestos = false;
      }
    },

    deleteResto(id) {
      if (confirm('Are you sure you want to delete this restaurant?')) {
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
