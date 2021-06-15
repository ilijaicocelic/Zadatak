<template>
    <div>
            <div id="nav">
       <router-link :to="{ name: 'students', params: { userId: currentUser.id}}">Students</router-link>|
       <router-link :to="{ name: 'courses', params: { userId: currentUser.id}}">Courses</router-link>|
       <router-link to="/">
        <b-button type="submit" @click="login" variant="danger"  >   Logout   </b-button>
    </router-link>
    </div>
        <h1> {{ clickedUser.name }}  {{ clickedUser.surname }} ({{ clickedUser.indexNumber }}) </h1>
        <b-img left src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Left image"></b-img>
        <b-img right src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Right image"></b-img>
        <p> Type of student: {{ clickedUser.status }} </p>
        <p> Index Number : {{ clickedUser.indexNumber }} </p>
        <p>Collegue year: {{ clickedUser.year }} </p>
        <p> Role: {{ clickedUser.role }} </p>

        <button @click="toggleStudForm" class="btn btn-primary"> Change Student</button>
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
       <b-form-group id="input-group-2" label="Surname:"  label-for="input-2">
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
          placeholder="Enter username"
          required
        ></b-form-input>
      </b-form-group>
      <b-form-group id="input-group-2" label="Password:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="password"
          placeholder="Enter new password"
          required
        ></b-form-input>
      </b-form-group>
         <b-button type="submit" variant="primary">Submit</b-button>
    </b-form>
    </div>
</template>

<script>

export default {
    data () {
        return {
            currentUser: {},
            clickedUser: {},
            id1: '',
            id2: '',
            user: {},
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
            this.axios.put('http://localhost:62612/api/user/ModifyStudent/' + this.id2, data)
            .then((respond) => {
                     this.id1 = this.$route.params.id
              this.axios.get('http://localhost:62612/api/user/getUser/' + this.id1)
            .then((respond) => {
                this.clickedUser = respond.data
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
         this.id1 = this.$route.params.userId
              this.axios.get('http://localhost:62612/api/user/getUser/' + this.id1)
            .then((respond) => {
                this.currentUser = respond.data
             })

         this.id2 = this.$route.params.id
              this.axios.get('http://localhost:62612/api/user/getUser/' + this.id2)
            .then((respond) => {
                this.clickedUser = respond.data
             })
    }
}
</script>
