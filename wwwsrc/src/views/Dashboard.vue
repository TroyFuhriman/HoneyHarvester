<template>
  <div class="dashboard">
    <h1>Welcome Home {{profile.name}}</h1>
    {{ profile }}
    {{ profiles }}
    {{ this.$auth.user }}
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
    this.$store.dispatch("getProfiles");
    this.findProfile;
  },
  computed: {
    profiles() {
      return this.$store.state.profiles;
    },
    profile() {
      return this.$store.state.activeProfile;
    },
    findProfile() {
      let profileId = 0;
      if (this.$auth.user) {
        for (let i = 0; i < this.profiles.length; i++) {
          let profile = this.profiles[i];
          if (profile.userId == this.$auth.user.sub) {
            profileId = profile.id;
            this.$store.dispatch("getProfile", profileId);
            return console.log("welcome back");
          }
        }
        // this.$store.dispatch("createProfile", this.newProfile);
        // return console.log("you don't have a profile yet!");
      }
      return console.log("Please sign in");
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  },
};
</script>
