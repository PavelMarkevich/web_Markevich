<template>
  <div id="mainBody" class="container">
    <h3 class="mt-3 row col-md-2 offset-md-5">New books</h3>
    <section class="text-center mb-4">
      <div class="row">
        <div class="col-md-3 mb-4 " v-for="book in books">
          <div class="card mt-3" style="width: 250px;">
            <div class="text-right"><span class="badge badge-secondary badge-danger">New</span></div>
            <div class="text-center">
              <img :src="book.ImageSrc" class="img-fluid">
            </div>
            <div class="card-body">
              <h5 class="card-title">{{book.Name}}</h5>
              <h6 class="cart-text">Author: {{book.Author}}</h6>
              <h6 class="cart-text">Year: {{book.Year}}</h6>
              <router-link to="/likedbooks"><button type="button" class="btn btn-primary btn-sm">Open</button></router-link>
            </div>
          </div>
        </div>
      </div>
    </section>

  </div>
</template>

<script>
  import axios from "axios";

  export default {
        data(){
          return{
            books:''
          }
        },
      created() {
        axios.get('https://localhost:44397/api/Book').then(resp=>this.books=resp.data).catch(e=>alert(e.response.data));

      }
  }
</script>

<style scoped>
.badge{
  width: 4em;
}
img{
  height: 160px;
  /**width: 120px;*/
}
</style>
