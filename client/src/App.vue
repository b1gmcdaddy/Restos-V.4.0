<template>
  <div class="background-container">
    <Banner />
    <div class="grid grid-cols-2 gap-12 mx-auto w-[80%]">
      <!--------------FORM TO ADD RESTOS------------>
        <div class="bg-white mt-5">
          <form>
            <label>Restaurant:</label>
            <input name="resto" type="text" class="border-2 border-black" />
            <label>Type:</label>
            <select class="border-2 border-black">
              <option>Meal</option>
              <option>Snack</option>
              <option>Dessert</option>
            </select>
            <label>Description:</label>
            <input name="resto" type="textarea" class="border-2 border-black" />

            <button type="submit" class="border border-black">Add Resto</button>
          </form>
        </div>
        <!------------LIST OF ENTRIES--------------->
        <div class="bg-white flex mt-5">
          <ul>
      <li v-for="resto in restos" :key="resto.id">
        <h2>{{ resto.resto }}</h2>
        <p>{{ resto.description }}</p>
        <p>Type: {{ resto.type }}</p>
        <p>Rating: {{ resto.rating }}</p>
        <p>Visited: {{ resto.isVisited ? 'Yes' : 'No' }}</p>
      </li>
    </ul>
        </div>
    </div>
  </div>
</template>

<script>
import Banner from './components/Banner.vue';
import api from './services/api.js';

export default {
  name: 'App',
  components: {
    Banner
  },
  data() {
    return {
      restos: []
    };
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
          console.error('Error fetching restaurants:', error);
        });
    }
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
