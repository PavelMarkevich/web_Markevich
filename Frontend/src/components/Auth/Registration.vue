<template>
  <div id="regBody">
    <div class="container">
      <h3 class="row col-md-2 offset-5 pt-3">Registration</h3>
      <form>
        <div class="form-group row col-md-6 offset-md-3">
          <label for="firstName">First Name</label>
          <input type="text" class="form-control" v-bind:class="{'is-invalid': $v.firstName.$error, 'is-valid': !$v.firstName.$invalid}" id="firstName"  v-model.trim="firstName" v-on:blur="$v.firstName.$touch()">
          <div class="invalid-feedback" v-if="!$v.firstName.required">
            Required field.
          </div>
          <div class="invalid-feedback" v-if="!$v.firstName.maxLength">
            The maximum length of the first name {{$v.firstName.$params.maxLength.max}} symbols. Now it is {{firstName.length}} symbols.
          </div>
          <div class="valid-feedback">Ok.</div>
        </div>
        <div class="form-group row col-md-6 offset-md-3">
          <label for="secondName">Second Name</label>
          <input type="text" class="form-control" v-bind:class="{'is-invalid': $v.secondName.$error, 'is-valid': !$v.secondName.$invalid}" id="secondName"  v-model.trim="secondName" v-on:blur="$v.secondName.$touch()">
          <div class="invalid-feedback" v-if="!$v.secondName.required">
            Required field.
          </div>
          <div class="invalid-feedback" v-if="!$v.secondName.maxLength">
            The maximum length of the first name {{$v.secondName.$params.maxLength.max}} symbols. Now it is {{secondName.length}} symbols.
          </div>
          <div class="valid-feedback">Ok.</div>
        </div>
        <div class="form-group row col-md-6 offset-md-3">
          <label for="phoneNumber">Mobile phone</label>
          <input type="tel" class="form-control" v-bind:class="{'is-invalid': $v.phoneNumber.$error, 'is-valid': !$v.phoneNumber.$invalid}" id="phoneNumber"  v-model.trim="phoneNumber" v-on:blur="$v.phoneNumber.$touch()">
          <div class="invalid-feedback" v-if="!$v.phoneNumber.required">
            Required field.
          </div>
          <div class="invalid-feedback" v-if="!$v.phoneNumber.maxLength">
            The maximum length of the phone number {{$v.phoneNumber.$params.maxLength.max}} symbols. Now it is {{phoneNumber.length}} symbols.
          </div>
          <div class="valid-feedback">Ok.</div>
        </div>
        <div class="form-group row col-md-6 offset-md-3">
          <label for="inputEmail1">Email</label>
          <input type="email" class="form-control" v-bind:class="{'is-invalid': $v.email.$error, 'is-valid': !$v.email.$invalid}" id="inputEmail1"  v-model="email" v-on:blur="$v.email.$touch()">
          <div class="invalid-feedback" v-if="!$v.email.required">
            Required field.
          </div>
          <div class="invalid-feedback" v-if="!$v.email.email">
            Incorrect format of email.
          </div>
          <div class="valid-feedback">Ok.</div>
        </div>
        <div class="form-group row col-md-6 offset-md-3">
          <label for="inputPassword">Password</label>
          <input type="password" class="form-control"  v-bind:class="{'is-invalid': $v.password.$error, 'is-valid': !$v.password.$invalid}" id="inputPassword" v-model="password" v-on:blur="$v.password.$touch()">
          <div class="invalid-feedback" v-if="!$v.password.minLength">
            The length of password must be at leat {{$v.password.$params.minLength.min}} symbols. Now it is {{password.length}} symbols.
          </div>
          <div class="invalid-feedback" v-if="!$v.password.required">
            This field is compulsory.
          </div>
          <div class="valid-feedback">Ok.</div>
        </div>
        <div class="form-group row col-md-6 offset-md-3">
          <label for="confirmPassword">Confirm Password</label>
          <input type="password" class="form-control"  v-bind:class="{'is-invalid': !$v.confirmPassword.sameAs, 'is-valid': !$v.confirmPassword.$invalid }" id="confirmPassword" v-model="confirmPassword" v-on:blur="$v.confirmPassword.$touch()">
          <div class="invalid-feedback" v-if="!$v.confirmPassword.sameAs">
            Passwords don't match.
          </div>
          <div class="valid-feedback">Ok.</div>
        </div>
        <button v-if="!isLoading" type="submit" class="btn btn-success row col-md-2 offset-md-5 mb-3"  v-bind:disabled="$v.$invalid" v-on:click.prevent="Register($event)">Create account</button>
        <img v-else class="row col-md-2 offset-md-5 mb-3" src="static/loading.gif" width="110px">
      </form>
    </div>
  </div>
</template>

<script>
  import axios from 'axios'
  import {email, minLength, maxLength, required, sameAs} from "vuelidate/lib/validators";

  export default {
    data(){
      return{
        firstName:'',
        secondName:'',
        email:'',
        phoneNumber:'',
        password:'',
        confirmPassword:''
      }
    },
    computed:{
      isLoading(){
        return this.$store.getters.loading;
      }
    },
    validations:{
      firstName: {
        required,
        maxLength: maxLength(20)
      },
      secondName: {
        required,
        maxLength: maxLength(20)
      },
      email:{
        required,
        email
      },
      phoneNumber: {
        required,
        maxLength:maxLength(15)
      },
      password: {
        required,
        minLength: minLength(6)
      },
      confirmPassword: {
        required,
        sameAs:sameAs('password')
      }
    },
    methods:{
      Register(event){
        this.$store.commit('setLoading', true);
        let registerData = {
          FirstName:this.firstName,
          SecondName:this.secondName,
          Email:this.email,
          PhoneNumber:this.phoneNumber,
          Password:this.password,
          ConfirmPassword:this.confirmPassword
        };
        axios.post('https://localhost:44397/api/Account/Register',registerData).
        then(resp=> {
         alert("Registration is successful");
         this.$router.push('/');
         this.$store.commit('setLoading', false);
       }).
       catch(error=>{
         console.log(error.response.data);
         alert(`Registration is failed.\n${error.response.data.join('\n')}`);
         this.$store.commit('setLoading', false);
       });
      }
    }
  }
</script>

<style scoped>
  #regBody{
    background-color: #f8fbee;
  }
</style>
