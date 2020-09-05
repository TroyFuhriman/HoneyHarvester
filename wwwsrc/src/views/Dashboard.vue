<template>
  <div class="dashboard container-fluid">
    <h1 class="text-center">Welcome {{profile.name}} to Honey Harvest!</h1>
    <div class="row justify-content-center">
      <img
        @click="addHoneyOnClick"
        type="button"
        class="drag img-fluid rounded-circle col-6 col-md-2"
        src="../assets/beehive.jpg"
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
      <tools v-for="tool in tools" :key="tool.id" :tool="tool">{{tool.name}}</tools>
    </div>
  </div>
</template>

<script>
import tools from "@/components/tools";
export default {
  data() {
    return {
      newProfile: {
        name: this.$auth.user.nickname,
      },
      tools: [
        {
          id: 0,
          name: "Honey Scraper",
          price: 5,
          description: "Increases Collection by 1",
          upgrade: 1,
          img: require("../assets/scraper.jpg"),
          count: 0,
          click: true,
        },
        {
          id: 2,
          name: "New Hive",
          price: 5,
          description: "Increases Collection by 5",
          upgrade: 5,
          img: require("../assets/hive2.jpg"),
          count: 0,
          click: true,
        },
        {
          id: 3,
          name: "Hire Beekeeper",
          price: 5,
          description: "Automated Collection",
          upgrade: 1,
          img: require("../assets/beekeeper.jpg"),
          count: 0,
          click: false,
        },
        {
          id: 4,
          name: "Robots!",
          price: 5,
          description: "Super Automated Collection",
          upgrade: 100,
          img: require("../assets/robot.jpg"),
          count: 0,
          click: false,
        },
      ],
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
    scraper() {},
  },
  components: {
    tools,
  },
};
</script>
<style scoped>
.drag {
  user-select: none;
  -moz-user-select: none;
  -webkit-user-drag: none;
  -webkit-user-select: none;
  -ms-user-select: none;
}
</style>
