<template>
    <div class="container-fluid" >
      <p>Book store page</p>
    </div>
</template>

<script>
  import axios from 'axios'
  export default {
    data(){
      return{

      }
    },
    created(){
      axios.get('https://localhost:44397/api/Account/UserInfo',{
        headers:{
          'Authorization':'Bearer '+ sessionStorage.getItem('token')
        }
      }).
      then(resp=>console.log(resp.data)).
      catch(e=>console.log(e.response.data))
    }
  }
</script>

<style scoped>

</style>

