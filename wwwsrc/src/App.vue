<template>
  <div class="bg-image bg-secondary" id="app">
    <navbar />
    <router-view />
  </div>
</template>

<script>
import Navbar from "@/components/navbar";
import { onAuth } from "@bcwdev/auth0-vue";
import { setBearer } from ".//store/AxiosService";
export default {
  name: "App",
  async beforeCreate() {
    await onAuth();
    // this.$store.dispatch("setBearer", this.$auth.bearer);
    setBearer(this.$auth.bearer);
    this.$store.dispatch("getProfile");
  },
  components: {
    Navbar,
  },
};
</script>

<style lang="scss">
@import "bootstrap";
@import "./assets/flatly.scss";
// @import "./assets/_overrides.scss";
</style>
<style >
#app {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}
.bg-image {
  background-image: url(./assets/honeycomb.png);
}
</style>
