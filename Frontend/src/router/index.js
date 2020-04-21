import Vue from 'vue'
import Router from 'vue-router'

import Main from "../components/Main";
import Registration from "../components/Auth/Registration";
import About from "../components/Info/About";
import Contact from "../components/Info/Contact";
import BookStore from "../components/BookStore/BookStore";
import LikedBooks from "../components/User/LikedBooks";
import NotFound from "../components/NotFound";
import AuthGuard from './auth-guard'
import AddBook from "../components/User/AddBook";

Vue.use(Router);

export default new Router({
  routes: [
   {
      path:'/',
      component: Main,
      name:'main'
    },
    {
      path:'/register',
      component: Registration,
      name:'register'
    },
    {
      path:'/about',
      component: About,
      name:'about'
    },
    {
      path:'/contact',
      component: Contact,
      name:'contact'
    },
    {
      path:'/bookstore',
      component: BookStore,
      name:'bookstore',
      beforeEnter:AuthGuard
    },
    {
      path:'/likedbooks',
      component: LikedBooks,
      name:'likedbooks',
      beforeEnter:AuthGuard
    },
    {
      path:'/addbook',
      component: AddBook,
      name:'addbook'
    },
    {
      path:'*',
      component: NotFound,
      name:'NotFound'
    }
  ],
  mode: 'history'
})
