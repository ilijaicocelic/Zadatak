<template>
    <div>
         <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/NonLogedStudents">Students</router-link>|
      <router-link to="/NonLogedCourses">Courses</router-link>|
    </div>
        <h1 class="text-monospace" > {{ currentCourse.name }} </h1>
        <b-img left src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Left image"></b-img>
        <b-img right src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Right image"></b-img>
        <br>
        <br>
        <br>
        <h4 class="text-monospace" >Course name: {{ currentCourse.name }} </h4>
         <h4 class="text-monospace" >Head Teacher : {{ currentCourse.headTeacher }} </h4>
         <br>
    </div>
</template>

<script>
import { mapState } from 'vuex'

export default {
    data () {
        return {
            currentCourse: {}
        }
    },
    computed: {
        ...mapState([
            'courses'
        ])
    },
    mounted () {
        const temp = this.courses[this.$route.params.id]
        this.currentCourse = temp
    }
}
</script>
