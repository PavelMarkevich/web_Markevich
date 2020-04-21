<template>
  <div class="container mt-3">
      <div class="form-group row col-md-6 offset-md-3">
        <label for="bookName">Book Name</label>
        <input type="text" class="form-control" id="bookName" v-bind:class="{'is-invalid': $v.bookName.$error}" v-model="bookName" v-on:blur="$v.bookName.$touch()">
        <div class="invalid-feedback" v-if="!$v.bookName.maxLength">
          The maximum length of the book name {{$v.bookName.$params.maxLength.max}} symbols. Now it is {{bookName.length}} symbols.
        </div>
        <div class="invalid-feedback" v-if="!$v.bookName.required">
          Required.
        </div>
      </div>
      <div class="form-group row col-md-6 offset-md-3">
        <label for="bookYear">Year</label>
        <input type="text" class="form-control"  id="bookYear" v-model="bookYear" v-bind:class="{'is-invalid': $v.bookYear.$error}"  v-on:blur="$v.bookYear.$touch()">
        <div class="invalid-feedback" v-if="!$v.bookYear.between">
          Year must be between {{$v.bookYear.$params.between.min}} - {{$v.bookYear.$params.between.max}}
        </div>
        <div class="invalid-feedback" v-if="!$v.bookYear.required">
          Required.
        </div>
      </div>
      <div class="form-group row col-md-6 offset-md-3">
      <label for="bookAuthors">Authors</label>
      <input type="text" class="form-control"  id="bookAuthors" v-model="bookAuthors" v-bind:class="{'is-invalid': $v.bookAuthors.$error}"  v-on:blur="$v.bookAuthors.$touch()">
        <div class="invalid-feedback" v-if="!$v.bookAuthors.maxLength">
          The maximum length of the book name {{$v.bookAuthors.$params.maxLength.max}} symbols. Now it is {{bookAuthors.length}} symbols.
        </div>
        <div class="invalid-feedback" v-if="!$v.bookAuthors.required">
          Required.
        </div>
     </div>
      <div class="form-group row col-md-6 offset-md-3">
        <label for="bookDescription">Description</label>
        <textarea class="form-control" id="bookDescription" rows="7" cols="30" v-model="bookDescription" v-bind:class="{'is-invalid': $v.bookDescription.$error}"  v-on:blur="$v.bookDescription.$touch()"></textarea>
        <div class="invalid-feedback" v-if="!$v.bookDescription.maxLength">
          The maximum length of the book name {{$v.bookDescription.$params.maxLength.max}} symbols. Now it is {{bookDescription.length}} symbols.
        </div>
        <div class="invalid-feedback" v-if="!$v.bookDescription.required">
          Required.
        </div>
      </div>
    <div class="row col-md-6 offset-md-3">
      <button type="button" class="btn btn-primary" v-on:click="triggerUpload" v-bind:class="{'is-invalid': $v.bookImageSrc.$invalid}">Upload image</button>
      <input ref="fileInput" type="file"  style="display: none" accept="image/*" v-on:change="onFileChange($event)">
      <div class="invalid-feedback" v-if="!$v.bookImageSrc.required">
        Image is required.
      </div>
    </div>
    <div class="row col-md-6 offset-md-3 mt-3 mb-2">
      <img v-bind:src="bookImageSrc" height="190px" v-if="bookImageSrc">
    </div>
      <button v-if="!isLoading" type="submit" class="btn btn-success row col-md-2 offset-md-5 mb-3" v-bind:disabled="$v.$invalid" v-on:click.prevent="addBook" >Add book</button>
     <img v-else src="static/loading.gif" class="row col-md-2 offset-md-5 mb-3" width="110px">
  </div>
</template>

<script>
  import axios from 'axios'
  import {maxLength, required, between} from "vuelidate/lib/validators";

    export default {
      data(){
        return{
          bookName:'',
          bookYear:'',
          bookAuthors:'',
          bookDescription:'',
          bookImageSrc:''
        }
      },
      computed:{
        isLoading(){
          return this.$store.getters.loading;
        }
      },
      validations:{
        bookName: {
          required,
          maxLength:maxLength(40)
        },
        bookYear: {
          required,
          between: between(0,3000)
        },
        bookAuthors: {
          required,
          maxLength:maxLength(40)
        },
        bookDescription: {
          required,
          maxLength:maxLength(200)
        },
        bookImageSrc:{
          required
        }
      },
      methods:{
        triggerUpload(){
          this.$refs.fileInput.click();
        },
        onFileChange(event){
          const file = event.target.files[0];
          const reader = new FileReader();
          reader.onload=e=>{
            this.bookImageSrc=reader.result;
          };
          reader.readAsDataURL(file);
        },
        addBook(){
          this.$store.commit('setLoading', true);
          const book = {
            Name:this.bookName,
            Year:this.bookYear,
            Author:this.bookAuthors,
            Description:this.bookDescription,
            ImageSrc:this.bookImageSrc
          };
          axios.post('https://localhost:44397/api/Book',book).
          then(resp=>{
            this.$store.commit('setLoading', false);
            alert("Book has successfully added");
            this.bookName='';
            this.bookYear='';
            this.bookAuthors='';
            this.bookDescription='';
            this.bookImageSrc='';
          }).
          catch(error=>{
            this.$store.commit('setLoading', false);
            if (error.response) {
              // Request made and server responded
              console.log(error.response.data);
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

<style scoped>

</style>
