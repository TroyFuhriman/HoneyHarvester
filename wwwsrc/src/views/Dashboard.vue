<template>
  <div class="dashboard container-fluid">
    <h1>Welcome {{profile.name}}</h1>
    {{profile}}
    <div class="row">
      <div class="col text-center">
        <p>score: {{profile.score}}</p>
        <p>Auto: {{profile.autoUpgrades}}</p>
        <p>Click: {{profile.clickUpgrades}}</p>
        <button @click="profile.score++" class="btn btn-success">Click me</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      newProfile: {
        name: this.$auth.user.nickname,
      },
    };
  },
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getProfile");
  },
  computed: {
    profiles() {
      return this.$store.state.profiles;
    },
    profile() {
      return this.$store.state.activeProfile;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  },
};
</script>
