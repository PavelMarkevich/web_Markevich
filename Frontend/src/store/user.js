import axios from "axios";

export default {
  state:{
    user:null
  },
  mutations:{
    setUser(state, payload){
      state.user=payload;
    }
  },
  actions:{},
  getters:{
    user(state){
      return state.user;
    },
    isUserLoggedIn(state){
      return state.user!==null;
    }
  }
}
