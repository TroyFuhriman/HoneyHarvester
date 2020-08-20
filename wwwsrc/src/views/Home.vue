<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col text-center">
        <h1>
          Welcome
          <span @click="nameForm = !nameForm" v-if="!nameForm">{{profile.name}}</span>
          <div class="row justify-content-center">
            <div class="col-4">
              <span v-if="nameForm">
                <input v-model="profile.name" class="form-control" type="text" />
              </span>
            </div>
          </div>
        </h1>
        <button v-if="nameForm" @click="editProfile" class="btn btn-success btn-outline-dark">Change</button>
        <p>Let's play a fun game!</p>
        <button
          @click="$router.push({name: 'dashboard'})"
          class="btn btn-success btn-outline-dark"
        >Play!</button>
      </div>
    </div>
    <div class="row justify-content-center text-center">
      <div class="col-12">
        <h3>Top 10 High Scores:</h3>
      </div>
      <div v-for="user in profiles.slice(0, 10)" :key="user.id" class="col-12">
        <div class>
          <span>Player Name: {{user.name }}</span>
          <br />
          <span>Honey Collected: {{user.score}}</span>
        </div>
      </div>
    </div>
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
      nameForm: false,
    };
  },
  name: "home",
  mounted() {
    this.$store.dispatch("getProfile");
    this.$store.dispatch("getProfiles");
    // this.findProfile;
  },
  computed: {
    profiles() {
      return this.$store.state.profiles.sort(function (a, b) {
        return b.score - a.score;
      });
    },
    profile() {
      return this.$store.state.activeProfile;
    },
    // findProfile() {
    //   let profileId = 0;
    //   for (let i = 0; i < this.profiles.length; i++) {
    //     let profile = this.profiles[i];
    //     if (profile.userId == this.$auth.user.sub) {
    //       profileId = profile.id;
    //       this.$store.dispatch("getProfile", profileId);
    //       return console.log("welcome back");
    //     }
    //   }
    //   // this.$store.dispatch("createProfile", this.newProfile);
    //   return console.log("you don't have a profile yet!");
    //   return console.log("Please sign in");
    // },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    editProfile() {
      this.nameForm = false;
      this.$store.dispatch("editProfileName", this.profile);
    },
  },
};
</script>
