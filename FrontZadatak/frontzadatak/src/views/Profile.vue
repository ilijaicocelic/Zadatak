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
          v-model="formData.name"
          placeholder="Enter name"
          required
        ></b-form-input>
      </b-form-group>
       <b-form-group id="input-group-2" label="Surname:"  label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="formData.surname"
          placeholder="Enter surname"
          required
        ></b-form-input>
      </b-form-group>
       <b-form-group id="input-group-2" label="Index Number:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="formData.indexNumber"
          placeholder="Enter index number..."
          required
        ></b-form-input>
      </b-form-group>
        <b-form-group id="input-group-3" label="Year:" label-for="input-3">
        <b-form-select
          id="input-3"
          v-model="formData.year"
          :options="years"
          required
        ></b-form-select>
      </b-form-group>
       <b-form-group id="input-group-3" label="Type:" label-for="input-3">
        <b-form-select
          id="input-3"
          v-model="formData.type"
          :options="types"
          required
        ></b-form-select>
      </b-form-group>
         <b-button type="submit" variant="primary">Submit</b-button>
    </b-form>
    </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

export default {
    data () {
        return {
            currentUser: {},
            clickedUser: {},
            id1: '',
            id2: '',
            user: {},
            sRole: 'Normal student',
             showStudForm: false,
            formData: {
                name: '',
                surname: '',
                indexNumber: '',
                year: null,
                type: null,
                role: 1,
                username: '',
                password: ''
            },
            years: [{ text: 'Select One', value: null }, 1, 2, 3, 4],
            types: [{ text: 'Select One', value: null }, 'Regular', 'Advanced'],
            show: true
        }
    },
    computed: {
        ...mapState([
            'students'
        ])
    },
    methods: {
        ...mapActions([
            'modifyStudent'
        ]),
        toggleStudForm () {
            this.showStudForm = !this.showStudForm
        },
        handleSubmit () {
            const { name, surname, indexNumber, year, type, role, username, password } = this.formData
            const payload = {
                student: {
                    name,
                    surname,
                    indexNumber,
                    year,
                    type,
                    role,
                    username,
                    password
                 }
            }
            this.user.name = this.formData.name
            this.user.surname = this.formData.surname
            this.user.year = this.formData.year
            this.user.indexNumber = this.formData.indexNumber
            this.modifyStudent(payload)

            this.formData = {
                name: '',
                surname: '',
                indexNumber: '',
                year: null,
                type: null,
                role: 1
            }
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
        const user = this.students[this.$route.params.id]
         this.user = user

        if (user.role === 0) {
            this.sRole = 'Admin'
        }
        this.formData.username = user.username
        this.formData.password = user.password

        const temp = this.$route.params.userId
        for (let index = 0; index < this.students.length; index++) {
            if (this.students[index].username === temp) {
                this.currentUser = this.students[index]
            }
        }
    }
}
</script>
