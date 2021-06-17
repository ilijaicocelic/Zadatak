<template>
    <div>
         <div id="nav">
       <router-link :to="{ name: 'students', params: { userId: currentUser.id}}">Students</router-link>|
       <router-link :to="{ name: 'courses', params: { userId: currentUser.id}}">Courses</router-link>|
          <router-link to="/">
        <b-button type="submit" @click="login" variant="danger"  >   Logout   </b-button>
    </router-link>
    </div>
        <h1 class="text-monospace" >List of all students</h1>
        <b-table striped hover :items="students">
            <template #cell(id)="data">
        <!-- `data.value` is the value after formatted by the Formatter -->
             <router-link :to="`/profile/${currentUser.id}/${data.value}`">
               {{ data.value }}
                  </router-link>
             </template>
       </b-table>
       <button @click="toggleStudForm" class="btn btn-primary"> Add New Student</button>
       <b-form @submit.prevent="handleSubmit"  v-if="showStudForm">
        <br>
      <b-form-group id="input-group-2" label="Name:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="name"
          placeholder="Enter name"
          required
        ></b-form-input>
      </b-form-group>
       <b-form-group id="input-group-2" label="Surname:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="surname"
          placeholder="Enter surname"
          required
        ></b-form-input>
      </b-form-group>
       <b-form-group id="input-group-2" label="Index Number:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="indexNumber"
          placeholder="Enter index number..."
          required
        ></b-form-input>
      </b-form-group>
        <b-form-group id="input-group-3" label="Year:" label-for="input-3">
        <b-form-select
          id="input-3"
          v-model="year"
          :options="years"
          required
        ></b-form-select>
      </b-form-group>
       <b-form-group id="input-group-3" label="Type:" label-for="input-3">
        <b-form-select
          id="input-3"
          v-model="status"
          :options="statuses"
          required
        ></b-form-select>
      </b-form-group>
      <b-form-group id="input-group-2" label="Username:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="username"
          placeholder="Enter a new username"
          required
        ></b-form-input>
      </b-form-group>
      <b-form-group id="input-group-2" label="New Password:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="password"
          placeholder="Set his first password..."
          required
        ></b-form-input>
      </b-form-group>
      <b-button type="submit" variant="primary">Submit</b-button>
    </b-form>
    </div>
</template>

<script>

import axios from '../axios/api'

export default {
    data () {
        return {
            students: [],
            currentUser: {},
            id1: '',
            id2: '',
            showStudForm: false,
            name: '',
            surname: '',
            indexNumber: '',
            year: 1,
            status: 'Regular',
            username: '',
            password: '',
            role: 'Student',
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
        handleSubmit (event) {
            event.preventDefault()
            var data = { name: this.name, surname: this.surname, indexNumber: this.indexNumber, year: this.year, username: this.username, password: this.password, role: this.role, status: this.status }
            this.axios.post('http://localhost:62612/api/user/AddUser', data)
            .then((respond) => {
                     this.axios.get('http://localhost:62612/api/user/GetAllUsers')
            .then((respond) => {
                this.students = respond.data
                this.showStudForm = false
                this.name = ''
                this.surname = ''
                this.indexNumber = ''
                this.years = 1
                this.username = ''
                this.password = ''
                this.role = 'Student'
                this.status = 'Regular'
             })
             })
        }
    },
    mounted () {
        axios.get('user/GetAllUsers')
            .then((respond) => {
                this.students = respond.data
             })

              this.id1 = this.$route.params.userId
              this.axios.get('http://localhost:62612/api/user/getUser/' + this.id1)
            .then((respond) => {
                this.currentUser = respond.data
             })
    }
}
</script>
