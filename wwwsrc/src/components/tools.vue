<template>
  <div class="tool col-md-3 col-6 mb-4">
    <img
      @click="addTool"
      @mouseenter="hovered = true"
      @mouseout="hovered = false"
      class="img-fluid shadow rounded-top"
      :src="tool.img"
    />
    <div
      class="border border-dark shadow rounded-bottom bg-white opacity text-center"
      v-if="hovered"
    >
      <h5>{{tool.name}} | {{tool.price}} honey | amount: {{tool.count}}</h5>
      <p>{{tool.description}}</p>
    </div>
  </div>
</template>


<script>
export default {
  name: "tool",
  data() {
    return {
      hovered: false,
    };
  },
  computed: {
    profile() {
      return this.$store.state.activeProfile;
    },
    addTool() {
      this.tool.count++;
      this.profile.score -= this.tool.price;
      if (this.tool.click) {
        this.profile.clickUpgrade += this.tool.upgrade;
      } else {
        this.profile.autoUpgrade += this.tool.upgrade;
      }
    },
  },
  methods: {},
  components: {},
  props: ["tool"],
};
</script>


<style scoped>
.size {
  max-width: 100% !important ;
}
.opacity {
  opacity: 0.8;
}
</style>