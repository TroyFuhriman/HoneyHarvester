<template>
  <div class="dashboard container-fluid">
    <h1 class="text-center">Welcome {{profile.name}}</h1>
    <div class="row justify-content-center">
      <img
        @click="addHoneyOnClick"
        type="button"
        class="img-fluid rounded-circle col-9 col-md-3"
        src="../assets/honey.jpg"
        alt
      />
    </div>

    <div class="row justify-content-center">
      <div class="col-12 text-center">
        <p>score: {{profile.score}}</p>
      </div>
      <div class="col-6 text-center">
        <p>Auto: {{profile.autoUpgrades}} added every second</p>
      </div>
      <div class="col-6 text-center">
        <p>Click: {{profile.clickUpgrades}} added to every click</p>
      </div>
    </div>
    <div class="row">
      <div class="col-12 col-md-3">hello</div>
      <div class="col-12 col-md-3">hello</div>
      <div class="col-12 col-md-3">hello</div>
      <div class="col-12 col-md-3">hello</div>
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
    this.startInterval;
  },
  computed: {
    profiles() {
      return this.$store.state.profiles;
    },
    profile() {
      return this.$store.state.activeProfile;
    },
    startInterval() {
      setInterval(() => {
        this.profile.score += this.profile.autoUpgrades;
      }, 1000);
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    addHoneyOnClick() {
      this.profile.score += this.profile.clickUpgrades + 1;
      this.$store.dispatch("editProfile", this.profile);
    },
    addClickUpgrade() {
      this.profile.clickUpgrades++;
      this.$store.dispatch("editProfile", this.profile);
    },
    addAutoUpgrade() {
      this.profile.autoUpgrades++;
      this.$store.dispatch("editProfile", this.profile);
    },
  },
};
</script>
<style scoped>
.size {
  max-height: 30vh;
}
</style>
