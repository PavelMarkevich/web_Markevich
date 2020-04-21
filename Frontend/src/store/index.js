import Vue from 'vue'
import Vuex from 'vuex'

import book from './book'
import user from "./user";
import shared from "./shared";

Vue.use(Vuex);

export default new Vuex.Store({
  modules:{
    book, user, shared
  }
})
