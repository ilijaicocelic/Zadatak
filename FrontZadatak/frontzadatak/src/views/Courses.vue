<template>
    <div>
        <div id="nav">
       <router-link :to="{ name: 'students'}">Students</router-link>|
       <router-link :to="{ name: 'courses'}">Courses</router-link>|
       <router-link to="/">
        <b-button  @click="logout" variant="danger"  >   Logout   </b-button>
    </router-link>
    </div>
        <h1 class="text-monospace" >List of all courses</h1>
        <b-table striped hover :items="courses">
            <template #cell(id)="data">
        <!-- `data.value` is the value after formatted by the Formatter -->
             <router-link :to="`/courseprofile/${data.value}`">
               {{ data.value }}
                  </router-link>
             </template>
     </b-table>
      <button @click="toggleCourseForm" class="btn btn-primary"> Add New Course</button>
       <b-form @submit.prevent="handleSubmit"  v-if="showCourseForm">
        <br>
      <b-form-group id="input-group-2" label="Course Name:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="model.name"
          placeholder="Enter course name..."
          required
        ></b-form-input>
      </b-form-group> <b-form-group id="input-group-2" label="Head Teacher:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="model.teacher"
          placeholder="Enter the head teacher..."
          required
        ></b-form-input>
      </b-form-group>
      <b-button type="submit" variant="primary">Submit</b-button>
       </b-form>
    </div>
</template>

<script>

import axios from '../axios/api'
import router from '../router/index'

export default {
    data () {
        return {
            courses: [],
            showCourseForm: false,
            model: {
            name: '',
            teacher: ''
            }
        }
    },
    methods: {
        toggleCourseForm () {
            this.showCourseForm = !this.showCourseForm
        },
        async handleSubmit () {
            await axios.post('course/AddCourse', this.model).catch(() => {
                 alert('Error, cant add course!')
               router.go()
             })
             alert('Successfully added!')
           const respond = await axios.get('course/GetAllCourses')
                this.courses = respond.data
                this.showCourseForm = !this.showCourseForm
                this.model = {}
        },
        logout () {
            localStorage.user = null
            localStorage.token = null
            router.push('/')
        }
    },
    async mounted () {
         const response = await axios.get('course/GetAllCourses')
           this.courses = response.data
    }
}
</script>
