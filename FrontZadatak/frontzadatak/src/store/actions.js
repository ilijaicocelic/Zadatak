export default {
  addStudent: ({ commit }, payload) => {
      commit('appendStud', payload)
  },
  modifyStudent: ({ commit }, payload) => {
      commit('changeStud', payload)
      },
  addCourse: ({ commit }, payload) => {
      commit('appendCourse', payload)
  },
  modifyCourse: ({ commit }, payload) => {
      commit('changeCourse', payload)
  },
  login: ({ commit }, payload) => {
      commit('loginUser', payload)
  }
}
