import { createApp } from 'vue'
import App from './App.vue'
import './index.css'
import { library } from "@fortawesome/fontawesome-svg-core";
import { faUtensils } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

// Add the icon to the library
library.add(faUtensils);

// Create the app instance
const app = createApp(App);

// Register the FontAwesomeIcon component globally
app.component('font-awesome-icon', FontAwesomeIcon);

// Mount the app
app.mount('#app');
