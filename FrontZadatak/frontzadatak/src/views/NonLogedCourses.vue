<template>
    <div>
         <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/NonLogedStudents">Students</router-link>|
      <router-link to="/NonLogedCourses">Courses</router-link>|
    </div>
        <h1 class="text-monospace" >List of all courses</h1>
        <b-table striped hover :items="courses">
            <template #cell(name)="data">
        <!-- `data.value` is the value after formatted by the Formatter -->
             <router-link :to="`/NonLogedCP/${data.index}`">
               {{ data.value }}
                  </router-link>
             </template>
     </b-table>
    </div>
</template>
<script>
import { mapState } from 'vuex'

export default {
    computed: {
        ...mapState([
            'courses'
        ])
    }
}
</script>
