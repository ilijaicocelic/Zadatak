<template>
    <div>
         <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/NonLogedStudents">Students</router-link>|
      <router-link to="/NonLogedCourses">Courses</router-link>|
    </div>
        <h1> {{ clickedUser.name }}  {{ clickedUser.surname }} ({{ clickedUser.indexNumber }}) </h1>
        <b-img left src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Left image"></b-img>
        <b-img right src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Right image"></b-img>
        <p> Type of student: {{ clickedUser.status }} </p>
        <p> Index Number : {{ clickedUser.indexNumber }} </p>
        <p>Collegue year: {{ clickedUser.year }} </p>
        <p> Role: {{ clickedUser.role }} </p>
    </div>
</template>

<script>

export default {
    data () {
        return {
            id1: '',
            clickedUser: {}
        }
    },
    mounted () {
         this.id1 = this.$route.params.id
              this.axios.get('http://localhost:62612/api/user/getUser/' + this.id1)
            .then((respond) => {
                this.clickedUser = respond.data
             })
    }
}
</script>
