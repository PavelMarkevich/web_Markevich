<template>
   <div class="container-fluid contact-form">
     <div class="row pt-3 pb-3" >
       <div class="col-md-3 offset-md-1">
         <h1>Get in Touch</h1>
       </div>
          <div class="col-md-7 right">
            <form>
              <div class="form-group row col-md-9 offset-md-1" >
                <input type="text" class="form-control"
                       placeholder="Your Name"
                       v-bind:class="{'is-invalid':$v.name.$error}"
                       v-model.trim="name" v-on:blur="$v.name.$touch()">
                <div class="invalid-feedback" v-if="!$v.name.required">
                  The field is required.
                </div>
                <div class="invalid-feedback" v-if="!$v.name.maxLength">
                  The length of name must be no more than {{$v.name.$params.maxLength.max}} symbols. Now it is {{name.length}} symbols.
                </div>
              </div>
              <div class="form-group row col-md-9 offset-md-1">
                <input type="email" class="form-control " placeholder="Your Email"
                       v-bind:class="{'is-invalid': $v.email.$error}"  v-model="email" v-on:blur="$v.email.$touch()">
                <div class="invalid-feedback" v-if="!$v.email.required">
                  Required field.
                </div>
                <div class="invalid-feedback" v-if="!$v.email.email">
                  Incorrect format of email.
                </div>
              </div>
              <div class="form-group row col-md-9 offset-md-1">
                <textarea class="form-control " placeholder="Your message" rows="5" cols="15 "
                          v-bind:class="{'is-invalid': $v.message.$error}"  v-model="message" v-on:blur="$v.message.$touch()"></textarea>
                <div class="invalid-feedback" v-if="!$v.message.required">
                  Required field.
                </div>
                <div class="invalid-feedback" v-if="!$v.message.maxLength">
                  The length of name must be no more than {{$v.message.$params.maxLength.max}} symbols. Now it is {{message.length}} symbols.
                </div>
              </div>
                <input type="submit" class="btn btn-secondary row col-md-9 offset-md-1"
                       v-bind:disabled="$v.$invalid" v-on:submit.prevent="onSubmit" value="Send">
            </form>
         </div>
       </div>
     </div>
</template>

<script>
  import {required, email, maxLength} from 'vuelidate/lib/validators'

    export default {
      data(){
        return{
          name:'',
          email:'',
          message:''
        }
      },
      validations:{
        name:{
          required,
          maxLength:maxLength(30)
        },
        email:{
          required,
          email
        },
        message: {
          required,
          maxLength:maxLength(120)
        }
      }
    }
</script>

<style scoped>
.contact-form{
  position: relative;
  background-color: #f8fbee;
}
.contact-form h1{
  padding:2em 1px;
  color: #F97300;
}
.contact-form .right .btn-secondary{
  background:  #F97300;
  color: #fff;
  border:0;
}
</style>
