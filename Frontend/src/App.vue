<template>
 <div id="app">
     <nav class="navbar navbar-expand-lg navbar-light">
       <router-link to="/" class="navbar-brand nav-link">Library</router-link>
       <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarContent" aria-controls="navbarContent" aria-expanded="false" aria-label="Toggle navigation">
         <span class="navbar-toggler-icon"></span>
       </button>
       <div class="collapse navbar-collapse" id="navbarContent">
         <div class="navbar-nav" v-if="isUserLoggedIn">
             <router-link to="/contact" class="nav-item nav-link">Contact
               <svg class="bi bi-envelope ml-2" width="1.6em" height="1.6em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                 <path fill-rule="evenodd" d="M14 3H2a1 1 0 00-1 1v8a1 1 0 001 1h12a1 1 0 001-1V4a1 1 0 00-1-1zM2 2a2 2 0 00-2 2v8a2 2 0 002 2h12a2 2 0 002-2V4a2 2 0 00-2-2H2z" clip-rule="evenodd"/>
                 <path fill-rule="evenodd" d="M.071 4.243a.5.5 0 01.686-.172L8 8.417l7.243-4.346a.5.5 0 01.514.858L8 9.583.243 4.93a.5.5 0 01-.172-.686z" clip-rule="evenodd"/>
                 <path d="M6.752 8.932l.432-.252-.504-.864-.432.252.504.864zm-6 3.5l6-3.5-.504-.864-6 3.5.504.864zm8.496-3.5l-.432-.252.504-.864.432.252-.504.864zm6 3.5l-6-3.5.504-.864 6 3.5-.504.864z"/>
               </svg>
             </router-link>
             <router-link to="/about" class="nav-item nav-link">About library
               <svg class="bi bi-info-square-fill ml-2" width="1.6em" height="1.6em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                 <path fill-rule="evenodd" d="M0 2a2 2 0 012-2h12a2 2 0 012 2v12a2 2 0 01-2 2H2a2 2 0 01-2-2V2zm8.93 4.588l-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533L8.93 6.588zM8 5.5a1 1 0 100-2 1 1 0 000 2z" clip-rule="evenodd"/>
               </svg>
             </router-link>
             <router-link to="/bookstore" class="nav-item nav-link">Book store
               <svg class="bi bi-book ml-2" width="1.6em" height="1.6em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                 <path fill-rule="evenodd" d="M3.214 1.072C4.813.752 6.916.71 8.354 2.146A.5.5 0 018.5 2.5v11a.5.5 0 01-.854.354c-.843-.844-2.115-1.059-3.47-.92-1.344.14-2.66.617-3.452 1.013A.5.5 0 010 13.5v-11a.5.5 0 01.276-.447L.5 2.5l-.224-.447.002-.001.004-.002.013-.006a5.017 5.017 0 01.22-.103 12.958 12.958 0 012.7-.869zM1 2.82v9.908c.846-.343 1.944-.672 3.074-.788 1.143-.118 2.387-.023 3.426.56V2.718c-1.063-.929-2.631-.956-4.09-.664A11.958 11.958 0 001 2.82z" clip-rule="evenodd"/>
                 <path fill-rule="evenodd" d="M12.786 1.072C11.188.752 9.084.71 7.646 2.146A.5.5 0 007.5 2.5v11a.5.5 0 00.854.354c.843-.844 2.115-1.059 3.47-.92 1.344.14 2.66.617 3.452 1.013A.5.5 0 0016 13.5v-11a.5.5 0 00-.276-.447L15.5 2.5l.224-.447-.002-.001-.004-.002-.013-.006-.047-.023a12.582 12.582 0 00-.799-.34 12.96 12.96 0 00-2.073-.609zM15 2.82v9.908c-.846-.343-1.944-.672-3.074-.788-1.143-.118-2.387-.023-3.426.56V2.718c1.063-.929 2.631-.956 4.09-.664A11.956 11.956 0 0115 2.82z" clip-rule="evenodd"/>
               </svg>
             </router-link>
             <router-link to="/likedbooks" class="nav-item nav-link">My books
               <svg class="bi bi-bookmark-fill ml-2" width="1.6em" height="1.6em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                 <path fill-rule="evenodd" d="M3 3a2 2 0 012-2h6a2 2 0 012 2v12l-5-3-5 3V3z" clip-rule="evenodd"/>
               </svg>
             </router-link>
           <span class="nav-item nav-link">{{user.userName}}</span>
           <a class="nav-item nav-link" v-on:click.prevent="LogOut($event)">Log out
             <svg class="bi bi-box-arrow-in-right ml-2" width="1.6em" height="1.6em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
               <path fill-rule="evenodd" d="M8.146 11.354a.5.5 0 010-.708L10.793 8 8.146 5.354a.5.5 0 11.708-.708l3 3a.5.5 0 010 .708l-3 3a.5.5 0 01-.708 0z" clip-rule="evenodd"/>
               <path fill-rule="evenodd" d="M1 8a.5.5 0 01.5-.5h9a.5.5 0 010 1h-9A.5.5 0 011 8z" clip-rule="evenodd"/>
               <path fill-rule="evenodd" d="M13.5 14.5A1.5 1.5 0 0015 13V3a1.5 1.5 0 00-1.5-1.5h-8A1.5 1.5 0 004 3v1.5a.5.5 0 001 0V3a.5.5 0 01.5-.5h8a.5.5 0 01.5.5v10a.5.5 0 01-.5.5h-8A.5.5 0 015 13v-1.5a.5.5 0 00-1 0V13a1.5 1.5 0 001.5 1.5h8z" clip-rule="evenodd"/>
             </svg>
           </a>
         </div>

           <div class="navbar-nav" v-else >
             <router-link to="/contact" class="nav-item nav-link">Contact
               <svg class="bi bi-envelope ml-2" width="1.6em" height="1.6em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                 <path fill-rule="evenodd" d="M14 3H2a1 1 0 00-1 1v8a1 1 0 001 1h12a1 1 0 001-1V4a1 1 0 00-1-1zM2 2a2 2 0 00-2 2v8a2 2 0 002 2h12a2 2 0 002-2V4a2 2 0 00-2-2H2z" clip-rule="evenodd"/>
                 <path fill-rule="evenodd" d="M.071 4.243a.5.5 0 01.686-.172L8 8.417l7.243-4.346a.5.5 0 01.514.858L8 9.583.243 4.93a.5.5 0 01-.172-.686z" clip-rule="evenodd"/>
                 <path d="M6.752 8.932l.432-.252-.504-.864-.432.252.504.864zm-6 3.5l6-3.5-.504-.864-6 3.5.504.864zm8.496-3.5l-.432-.252.504-.864.432.252-.504.864zm6 3.5l-6-3.5.504-.864 6 3.5-.504.864z"/>
               </svg>
             </router-link>
             <router-link to="/about" class="nav-item nav-link">About library
               <svg class="bi bi-info-square-fill ml-2" width="1.6em" height="1.6em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                 <path fill-rule="evenodd" d="M0 2a2 2 0 012-2h12a2 2 0 012 2v12a2 2 0 01-2 2H2a2 2 0 01-2-2V2zm8.93 4.588l-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533L8.93 6.588zM8 5.5a1 1 0 100-2 1 1 0 000 2z" clip-rule="evenodd"/>
               </svg>
             </router-link>
             <router-link to="/register" class="nav-item nav-link">Registration
               <svg class="bi bi-person-lines-fill ml-2" width="1.6em" height="1.6em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                 <path fill-rule="evenodd" d="M1 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H1zm5-6a3 3 0 100-6 3 3 0 000 6zm7 1.5a.5.5 0 01.5-.5h2a.5.5 0 010 1h-2a.5.5 0 01-.5-.5zm-2-3a.5.5 0 01.5-.5h4a.5.5 0 010 1h-4a.5.5 0 01-.5-.5zm0-3a.5.5 0 01.5-.5h4a.5.5 0 010 1h-4a.5.5 0 01-.5-.5zm2 9a.5.5 0 01.5-.5h2a.5.5 0 010 1h-2a.5.5 0 01-.5-.5z" clip-rule="evenodd"/>
               </svg>
             </router-link>
             <a class="nav-item nav-link" data-toggle="modal" data-target="#loginmodal">Log in
             <svg class="bi bi-people-circle ml-2" width="1.6em" height="1.6em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
               <path d="M13.468 12.37C12.758 11.226 11.195 10 8 10s-4.757 1.225-5.468 2.37A6.987 6.987 0 008 15a6.987 6.987 0 005.468-2.63z"/>
               <path fill-rule="evenodd" d="M8 9a3 3 0 100-6 3 3 0 000 6z" clip-rule="evenodd"/>
               <path fill-rule="evenodd" d="M8 1a7 7 0 100 14A7 7 0 008 1zM0 8a8 8 0 1116 0A8 8 0 010 8z" clip-rule="evenodd"/>
             </svg>
             </a>
           </div>
         </div>
     </nav>
     <div class="header">
       <div class="overlay"></div>
       <div class="container">
         <div class="description">
           <h3>Hello ,Welcome To My officail Website</h3>
           <p>
             Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid ipsam libero vitae. Accusantium aliquid assumenda at
             atque culpa dolor eveniet fugit hic impedit ipsam, iure obcaecati omnis quae quos reiciendis rerum sapiente sed
             similique voluptatem voluptatibus. Accusantium consequuntur delectus ipsa obcaecati vel?
           </p>
         </div>
       </div>
     </div>
     <router-view></router-view>

   <!--<pre>{{this.$store.state.book.books}}</pre>
   <p v-for="book of this.$store.state.book.books">{{book.Id}} {{book.Name}} {{book.Year}}</p>
   <pre>{{this.$store.state.books1}}</pre>-->
   <footer class="page-footer text-center text-md-left">
     <div class="container-fluid">
       <div class="row">
         <div class="col-md-6 pt-2">
           <h5 class="title ">Footer Content</h5>
           <p>Here you can use rows and columns here to organize your footer content.</p>
         </div>
         <div class="col-md-6 pt-2">
           <h4 class="title ">Telephones</h4>
           <h6>Link 1</h6>
           <h6>Link 1</h6>
           <h6>Link 1</h6>
           <h6>Link 1</h6>
         </div>
       </div>
     </div>
     <div class="footer-copyright">
       <div class="container-fluid">
         <h4 class="pb-2">Kozlyakovskaya Tatsiana PM 172 2020</h4>
       </div>
     </div>
   </footer>

     <!-- Modal -->
     <div class="modal fade" id="loginmodal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
       <div class="modal-dialog modal-dialog-centered" role="document">
         <div class="modal-content">
           <div class="modal-header justify-content-center">
             <h5 class="modal-title" id="exampleModalCenterTitle">Authorization</h5>
             <button type="button" class="close" data-dismiss="modal" aria-label="Close">
               <span aria-hidden="true">&times;</span>
             </button>
           </div>
           <form>
             <div class="modal-body">
                   <div class="form-group">
                     <label for="inputEmailLog">Email</label>
                     <input type="email" class="form-control" v-bind:class="{'is-invalid': $v.email.$error}" id="inputEmailLog"  v-model="email" v-on:blur="$v.email.$touch()">
                     <div class="invalid-feedback" v-if="!$v.email.required">
                       Email is required field.
                     </div>
                     <div class="invalid-feedback" v-if="!$v.email.email">
                       Incorrect format of email.
                     </div>
                   </div>
                   <div class="form-group">
                     <label for="inputPasswordLog">Password</label>
                     <input type="password" class="form-control"  v-bind:class="{'is-invalid': $v.password.$error}" id="inputPasswordLog" v-model="password" v-on:blur="$v.password.$touch()">
                     <div class="invalid-feedback" v-if="!$v.password.minLength">
                       The length of password must be at least {{$v.password.$params.minLength.min}} symbols. Now it is {{password.length}} symbols.
                     </div>
                     <div class="invalid-feedback" v-if="!$v.password.required">
                       This field is compulsory.
                     </div>
                   </div>
                   <div class="modal-footer">
                     <button v-if="!isLoading" type="submit" class="btn btn-primary" v-bind:disabled="$v.$invalid" v-on:click.prevent="LogIn()">Log in</button>
                     <img v-else src="static/loading.gif" width="110px">
                   </div>
             </div>
           </form>
       </div>
     </div>
   </div>
 </div>
</template>

<script>
  import axios from 'axios'
  import {required, email, minLength} from 'vuelidate/lib/validators'
export default {
  data() {
    return{
      email:'',
      password:''
    }
  },
  computed:{
    isUserLoggedIn(){
      return this.$store.getters.isUserLoggedIn;
    },
    isLoading(){
      return this.$store.getters.loading;
    },
    user(){
      return this.$store.getters.user;
    }
  },
  validations:{
    email:{
      required,
      email
    },
    password: {
      required,
      minLength: minLength(6)
    }
  },
  methods:{
  LogIn() {
      this.$store.commit('setLoading', true);
      let loginData = encodeURI('userName=' + this.email+
        "&password=" + this.password +
        "&grant_type=password");
      axios.post('https://localhost:44397/Token',loginData,
      {
        headers: {'Content-Type': 'application/x-www-form-urlencoded'}
      }).
      then(resp=>{
       this.$store.commit('setLoading', false);
       sessionStorage.setItem('token', resp.data.access_token);
       $('#loginmodal').modal('toggle');
       this.$router.push('/about');
       this.$store.commit('setUser',{
         userName:resp.data.userName
       });
       this.email='';
       this.password='';
       console.log(this.$store.getters.user);
      }).
      catch(error=>{
        this.$store.commit('setLoading', false);
        if (error.response) {
          // Request made and server responded
          alert(error.response.data.error_description);
        }
        else{
          alert(error.message)
        }
      });
    },
    LogOut(event){
      axios.post('https://localhost:44397/api/Account/Logout',null,{
        headers:{
          'Authorization':'Bearer '+ sessionStorage.getItem('token')
        }
      }).
      then(resp=>{
        console.log("Logout is successful.");
        sessionStorage.removeItem('token');
        this.$router.push('/about');
        this.$store.commit('setUser',null);
      }).
      catch(error=>{
        if (error.response) {
          // Request made and server responded
          alert(error.response.data);
        }
        else {
          // Something happened in setting up the request that triggered an Error
          alert(error.message);
        }
      });
    }
  }
}
</script>
<style>
  #app{
    background-color: #f8fbee;
  }
  .navbar{
    background:#F97300;
  }
  .nav-link , .navbar-brand{
    color: #f4f4f4;
    cursor: pointer;
  }
  .nav-link{
    margin-right: 1em !important;
  }
  .nav-link:hover{
    background: #f4f4f4;
    color: #f97300;
  }
  .navbar-collapse{
    justify-content: flex-end;
  }
  .header{
    position: relative;
    background-image: url('../static/header.jpg');
    background-attachment: fixed;
    background-size: cover;
    background-position: center;
    height: 420px;
  }
  .overlay{
    position: relative;
    min-height: 100%;
    min-width: 100%;
    left: 0;
    top: 0;
    background: rgba(244, 244, 244, 0.5);
  }
  .description{
    position: absolute;
    top: 20%;
    margin: auto;
    padding: 2em;
  }
  .description h1{
    color: #f4f4f4;
  }
  .description p{
    color: black;
    font-size: 20px;
    width: 50%;
    line-height: 1.5;
  }
  .description button{
    border:1px  solid #F97300;
    background:#F97300;
    color:#fff;
    position: absolute;
  }
  #exampleModalCenterTitle{
   margin-left: 175px;
  }
  footer{
    background-color: #F97300;
  }
</style>

