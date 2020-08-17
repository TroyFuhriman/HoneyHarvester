<template>
  <div class="home">
    <h1>Welcome Home</h1>Let's play a fun game
  </div>
  <!-- I'm not sure how exactly I want to do the profile and the game start. I think it should be a one page type of thing, but it might be easier to do two page... -->
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
  name: "home",
  mounted() {},
  computed: {
    profiles() {
      return this.$store.state.profiles;
    },
    profile() {
      return this.$store.state.activeProfile;
    },
    findProfile() {
      let profileId = 0;
      for (let i = 0; i < this.profiles.length; i++) {
        let profile = this.profiles[i];
        if (profile.userId == this.$auth.user.sub) {
          profileId = profile.id;
          this.$store.dispatch("getProfile", profileId);
          return console.log("welcome back");
        }
      }
      // this.$store.dispatch("createProfile", this.newProfile);
      return console.log("you don't have a profile yet!");
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
