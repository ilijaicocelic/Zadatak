<template>
    <div>
             <div id="nav">
       <router-link :to="{ name: 'students'}">Students</router-link>|
       <router-link :to="{ name: 'courses'}">Courses</router-link>|
       <router-link to="/">
        <b-button @click="logout" variant="danger"  >   Logout   </b-button>
    </router-link>
    </div>
        <h1 class="text-monospace" > {{ model.name }} </h1>
        <b-img left src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Left image"></b-img>
        <b-img right src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Right image"></b-img>
        <br>
        <br>
        <br>
        <h4 class="text-monospace" >Course name: {{ model.name }} </h4>
         <h4 class="text-monospace" >Head Teacher : {{ model.teacher }} </h4>
         <br>
         <table class="table mt-5">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Name</th>
          <th scope="col">Username</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(entry, i) in studentList" :key="i">
          <th scope="row">{{ ++i }}</th>
          <td>{{ entry.name }}</td>
          <td>{{ entry.username }}</td>
          <td>
              <button @click="RemoveStudent(entry.id)" class="btn btn-primary"> Remove</button>
          </td>
        </tr>
      </tbody>
         </table>
      <br>
         <button @click="toggleCourseForm" class="btn btn-primary"> Modify Course Info</button>
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
            studentList: [],
            id2: {},
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
             await axios.put('course/ModifyCourse/' + this.id2, this.model).catch(() => {
                 alert('Error, cant modify course!')
               router.go()
             })
                alert('Successfully modified')
                this.id2 = this.$route.params.id
             const respond = await axios.get('course/GetCourse/' + this.id2)
               this.model = respond.data
            this.showCourseForm = !this.showCourseForm
        },
       async RemoveStudent (id) {
            await axios.delete('course/RemoveStudent/' + id + '/' + this.id2).catch(() => {
                 alert('Error, cant remove student from course!')
               router.go()
             })
                alert('Successfully removed')
            const respond = await axios.get('course/GetStudents/' + this.id2)
                this.studentList = respond.data
        },
        logout () {
            localStorage.user = null
            localStorage.token = null
            router.push('/')
        }
    },
    async mounted () {
         this.id2 = this.$route.params.id
             const respond = await axios.get('course/GetCourse/' + this.id2)
                this.model = respond.data
            const respond1 = await axios.get('course/GetStudents/' + this.id2)
                this.studentList = respond1.data
    }
}
</script>
