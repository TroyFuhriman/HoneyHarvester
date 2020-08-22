<template>
  <div class="tool col-md-3 col-12">
    <div class="row">
      <div class="col-md-12 col-6">
        <img class="img-fluid" :src="tool.img" alt />
      </div>
    </div>
    <h5>{{tool.name}}</h5>
    <p>{{tool.description}}</p>
  </div>
</template>


<script>
export default {
  name: "tool",
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: {},
  props: ["tool"],
};
</script>


<style scoped>
</style>