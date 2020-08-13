import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";
import { api } from "./AxiosService";

Vue.use(Vuex);
export default new Vuex.Store({
  state: {
    profiles: [],
    activeProfile: {},
  },
  mutations: {
    setProfiles(state, profiles) {
      state.profiles = profiles;
    },
    setActiveProfile(state, profile) {
      state.activeProfile = profile;
    },
  },
  actions: {
    async getProfiles({ commit, dispatch }) {
      try {
        let res = await api.get("profiles");
        commit("setProfiles", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getProfile({ commit, dispatch }, profileId) {
      try {
        let res = await api.get("profiles/" + profileId);
        commit("setActiveProfile", res.data);
      } catch (error) {
        console.error(error);
      }
    },
  },
});
