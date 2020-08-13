<template>
  <div class="home">
    <h1>Welcome Home</h1>
    {{ profiles }}
    {{ this.$auth.user }}
    <button @click="findProfile" class="btn btn-success">Hello</button>
  </div>
</template>

<script>
export default {
  name: "home",
  computed: {
    profiles() {
      return this.$store.state.profiles;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    findProfile() {
      profileId = 0;
      for (let i = 0; i < this.profiles.length; i++) {
        this.profiles[i];
      }
    },
  },
};
</script>
