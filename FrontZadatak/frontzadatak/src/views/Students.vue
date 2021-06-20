<template>
    <div>
         <div id="nav">
       <router-link :to="{ name: 'students' }">Students</router-link>|
       <router-link :to="{ name: 'courses' }">Courses</router-link>|
          <router-link to="/">
        <b-button  @click="logout" variant="danger"  >   Logout   </b-button>
    </router-link>
    </div>
        <h1 class="text-monospace" >List of all students</h1>
        <b-table striped hover :items="students">
            <template #cell(id)="data">
        <!-- `data.value` is the value after formatted by the Formatter -->
             <router-link :to="`/profile/${data.value}`">
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
          v-model="model.name"
          placeholder="Enter name"
          required
        ></b-form-input>
      </b-form-group>
       <b-form-group id="input-group-2" label="Surname:" label-for="input-2">
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
          placeholder="Enter a new username"
          required
        ></b-form-input>
      </b-form-group>
      <b-form-group id="input-group-2" label="New Password:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="model.password"
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
import router from '../router/index'

export default {
    data () {
        return {
            students: [],
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
            id1: '',
            id2: '',
            showStudForm: false,
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
        async handleSubmit () {
            await axios.post('user/AddUser', this.model).catch(() => {
                alert('Error, cant add student')
                router.push({ name: 'students' })
            })
            alert('Successfully added ')
            const respond1 = await axios.get('user/GetAllUsers')
            this.students = respond1.data
             this.model = {}
             this.showStudForm = !this.showStudForm
        },
        logout () {
            localStorage.user = null
            localStorage.token = null
            router.push('/')
        }
    },
   async mounted () {
     const respond = await axios.get('user/GetAllUsers').catch(() => {
         alert('Error')
     })
         this.students = respond.data
    }
}
</script>
