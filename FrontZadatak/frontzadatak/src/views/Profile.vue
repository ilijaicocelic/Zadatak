<template>
    <div>
            <div id="nav">
       <router-link :to="{ name: 'students'}">Students</router-link>|
       <router-link :to="{ name: 'courses'}">Courses</router-link>|
       <router-link to="/">
        <b-button  @click="logout" variant="danger"  >   Logout   </b-button>
    </router-link>
    </div>
        <h1> {{ model.name }}  {{ model.surname }} ({{ model.indexNumber }}) </h1>
        <b-img left src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Left image"></b-img>
        <b-img right src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Right image"></b-img>
        <p> Type of student: {{ model.status }} </p>
        <p> Index Number : {{ model.indexNumber }} </p>
        <p>Collegue year: {{ model.year }} </p>
        <p> Role: {{ model.role }} </p>

        <button @click="toggleStudForm" class="btn btn-primary"> Change Student</button>&nbsp;
        <button @click="toggleCourseForm" class="btn btn-primary"> Add to course</button>
        <b-form @submit.prevent="handleSubmit1"  v-if="showCourseForm">
            <b-form-group id="input-group-3" label="Select Course to Add:" label-for="input-3">
        <b-form-select
          id="input-3"
          v-model="addCourseModel.courseId"
          :options="courses"
          required
        ></b-form-select>
      </b-form-group>
       <b-button type="submit" variant="primary">Submit</b-button>
        </b-form>

        <b-form @submit.prevent="handleSubmit"  v-if="showStudForm">
        <br>
      <b-form-group id="input-group-2" label="Name:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="model.name"
          placeholder="Enter name"
          value="clickedUser.name"
          required
        ></b-form-input>
      </b-form-group>
       <b-form-group id="input-group-2" label="Surname:"  label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="model.surname"
          placeholder="Enter surname"
          required
        ></b-form-input>
      </b-form-group>
       <b-form-group id="input-group-2" label="Index Number:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="model.indexNumber"
          placeholder="Enter index number..."
          required
        ></b-form-input>
      </b-form-group>
        <b-form-group id="input-group-3" label="Year:" label-for="input-3">
        <b-form-select
          id="input-3"
          v-model="model.year"
          :options="years"
          required
        ></b-form-select>
      </b-form-group>
       <b-form-group id="input-group-3" label="Type:" label-for="input-3">
        <b-form-select
          id="input-3"
          v-model="model.status"
          :options="statuses"
          required
        ></b-form-select>
      </b-form-group>
      <b-form-group id="input-group-2" label="Username:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="model.username"
          placeholder="Enter username"
          required
        ></b-form-input>
      </b-form-group>
      <b-form-group id="input-group-2" label="Password:" label-for="input-2">
        <b-form-input
          id="input-2"
          v-model="model.password"
          placeholder="Enter new password"
          required
         type="password"
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
            id2: '',
            addCourseModel: {
                userId: '',
                courseId: ''
            },
            model: {
            name: '',
            surname: '',
            indexNumber: '',
            year: 1,
            status: 'Regular',
            username: '',
            password: '',
            role: 'Student'
            },
             showStudForm: false,
             showCourseForm: false,
            statuses: [
                { value: 'Regular', text: 'Regular Student' },
                { value: 'Extramural', text: 'Advanced Student' }
            ],
            years: [
                { value: 1, text: '1 year' },
                { value: 2, text: '2 year' },
                { value: 3, text: '3 year' },
                { value: 4, text: '4 year' }
            ]
        }
    },
    methods: {
        toggleStudForm () {
            this.showStudForm = !this.showStudForm
        },
        toggleCourseForm () {
            this.showCourseForm = !this.showCourseForm
        },
       async handleSubmit () {
           await axios.put('user/ModifyStudent/' + this.id2, this.model).catch(() => {
               alert('Error, cant modify student!')
               router.go()
           })
           alert('Successfully modified')
                  this.showStudForm = !this.showStudForm
        },
         async handleSubmit1 () {
             await axios.put('course/AddStudent', this.addCourseModel).catch(() => { alert('error') })
             alert('Succesfully added !')
             this.showCourseForm = !this.showCourseForm
         },
         logout () {
            localStorage.user = null
            localStorage.token = null
            router.push('/')
        }
    },
    async mounted () {
        const response = await axios.get('course/GetNamesOfCourses').catch(() => {
                alert('Error')
            })
            this.courses = response.data

         this.id2 = this.$route.params.id
              const response1 = await axios.get('user/getUser/' + this.id2)
            this.model = response1.data
            this.addCourseModel.userId = this.id2
    }
}
</script>
