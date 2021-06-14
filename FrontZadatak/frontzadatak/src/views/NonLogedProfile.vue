<template>
    <div>
         <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/NonLogedStudents">Students</router-link>|
      <router-link to="/NonLogedCourses">Courses</router-link>|
    </div>
        <h1> {{ user.name }}  {{ user.surname }} ({{ user.indexNumber }}) </h1>
        <b-img left src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Left image"></b-img>
        <b-img right src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Right image"></b-img>
        <p> Type of student: {{ user.type }} </p>
        <p> Index Number : {{ user.indexNumber }} </p>
        <p>Collegue year: {{ user.year }} </p>
        <p> Role: {{ sRole }} </p>
    </div>
</template>

<script>
import { mapState } from 'vuex'

export default {
    data () {
        return {
            user: {},
            sRole: 'Normal student'
        }
    },
    computed: {
        ...mapState([
            'students'
        ])
    },
    mounted () {
        const user = this.students[this.$route.params.id]
         this.user = user

        if (user.role === 0) {
            this.sRole = 'Admin'
        }
    }
}
</script>
