<template>
    <div>
         <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/NonLogedStudents">Students</router-link>|
      <router-link to="/NonLogedCourses">Courses</router-link>|
    </div>
        <h1 class="text-monospace" > {{ clickedCourse.name }} </h1>
        <b-img left src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Left image"></b-img>
        <b-img right src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Right image"></b-img>
        <br>
        <br>
        <br>
        <h4 class="text-monospace" >Course name: {{ clickedCourse.name }} </h4>
         <h4 class="text-monospace" >Head Teacher : {{ clickedCourse.teacher }} </h4>
         <br>
    </div>
</template>

<script>

export default {
    data () {
        return {
            id: '',
            clickedCourse: {}
        }
    },
    mounted () {
        this.id = this.$route.params.id
              this.axios.get('http://localhost:62612/api/course/GetCourse/' + this.id)
            .then((respond) => {
                this.clickedCourse = respond.data
             })
    }
}
</script>
