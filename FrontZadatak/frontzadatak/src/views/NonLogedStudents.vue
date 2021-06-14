<template>
    <div>
         <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/NonLogedStudents">Students</router-link>|
      <router-link to="/NonLogedCourses">Courses</router-link>|
    </div>
        <h1 class="text-monospace" >List of all students</h1>
        <b-table striped hover :items="students">
            <template #cell(name)="data">
        <!-- `data.value` is the value after formatted by the Formatter -->
             <router-link :to="`/NonLogedProfile/${data.index}`">
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
            'students'
        ])
    }
}
</script>
