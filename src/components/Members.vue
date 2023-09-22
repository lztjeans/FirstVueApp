<script setup>

</script>

<template>
  <div class="container">
    <div class="row">
      <div class="col-sm-10">
        <h1>Here is the list of Employees</h1>
        <hr/>
        <alert v-if="showMessage" :message="message"></alert>
        <button
            class="btn btn-success btn-sm"
            type="button"
            @click="toggleAddMemberModal">
          Add Member
        </button>
        <br/><br/>
        <table class="table table-hover" border="5">
          <thead>
            <tr>
              <th scope="col">ID</th>
              <th scope="col">Name</th>
              <th scope="col">Age</th>
              <th scope="col">Salary</th>
              <th scope="col">Department</th>
              <th scope="col">Sex</th>
              <th scope="col">Email</th>
              <th>action1</th>
              <th>action2</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(e, index) in members" :key="index">
              <td>{{ e.id }}</td>
              <td>{{ e.username }}</td>
              <td>{{ e.age }}</td>
              <td>{{ e.salary }}</td>
              <td>{{ e.department }}</td>
              <td>
                <span v-if="e.sex == 'F'">Female</span>
                <span v-else>Male</span>
              </td>
              <td>{{ e.email  }}</td>
              <td>
                <button
                      class="btn btn-warning btn-sm"
                      type="button"
                      @click="toggleEditMemberModal(e)">
                    Update
                </button>
              </td>
              <td>
                <button
                      class="btn btn-danger btn-sm"
                      type="button"
                      @click="handleDeleteClick(e)">
                    Delete
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
  <!-- <formmodal :action="action" :members="Members"/> -->
  <div v-show="activeAddModal || activeUpdateModal" class="modal-backdrop fade show"></div>
  
  <!-- add or edit Member modal -->
  <div :class="{ show: activeAddModal || activeUpdateModal , 'd-block': activeAddModal || activeUpdateModal}" class="modal fade" role="dialog" tabindex="-1">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 v-if="action == action_C" class="modal-title">Create</h5>
          <h5 v-else-if="action == action_U" class="modal-title">Update</h5>
          <!--button-->
          <button
              aria-label="Close"
              class="close"
              data-dismiss="modal"
              type="button"
              @click="handleCloseModal">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form>
            <!-- Member.id -->
            <div class="mb-3" v-show="action == action_U">
              <label class="form-label" for="memberId">ID:</label>
              <input
                  id="memberId"
                  v-model="memberForm.id"
                  class="form-control"
                  type="text" disabled/>
            </div>
            <!-- Member.username -->
            <div class="mb-3">
              <label class="form-label" for="memberusername">username:</label>
              <input
                  id="memberusername"
                  v-model="memberForm.username"
                  class="form-control"
                  placeholder="Enter username"
                  type="text"/>
            </div>
            <!-- Member.age -->
            <div class="mb-3">
              <label class="form-label" for="memberage">age:</label>
              <input
                  id="memberage"
                  v-model="memberForm.age"
                  class="form-control"
                  placeholder="Enter age"
                  type="text"/>
            </div>
            <!-- Member.salary -->
            <div class="mb-3">
              <label class="form-label" for="membersalary">salary:</label>
              <input
                  id="membersalary"
                  v-model="memberForm.salary"
                  class="form-control"
                  placeholder="Enter salary"
                  type="text"/>
            </div>
            <!-- Member.Dept   -->
            <div class="mb-3">
              <label class="form-label" for="memberDept">Department: </label>
              <select id="memberDept" v-model="memberForm.department">
                  <option value="Development">Development</option>
                  <option value="HR">HR</option>
                  <option value="Research">Research</option>
              </select>
            </div>
            <!-- Member.Sex -->
            <div class="mb-3 form-group">
              <label class="form-label" >Sex: </label>
              <input type="radio" v-model="memberForm.sex" value="M" />Male
              <input type="radio" v-model="memberForm.sex" value="F" />Female
              <!-- <input type="radio" v-model="this.member.sex" value="O" <p></p>/>LGTP -->
            </div>
            <!-- Member.email -->
            <div class="mb-3">
              <label class="form-label" for="memberemail">email:</label>
              <input
                  id="memberemail"
                  v-model="memberForm.email"
                  class="form-control"
                  placeholder="Enter email"
                  type="text"/>
            </div>
            <!-- Member.password -->
            <div class="mb-3">
              <label class="form-label" for="memberpassword">password:</label>
              <input
                  id="memberpassword"
                  v-model="memberForm.password"
                  class="form-control"
                  placeholder="Enter password"
                  type="password"/>
            </div>
            <!-- Button group-->
            <div class="btn-group" role="group">
              <button
                  class="btn btn-primary btn-sm"
                  type="button"
                  @click="handleSubmit">
                Submit
              </button>
              <button
                  class="btn btn-danger btn-sm"
                  type="button"
                  @click="handleReset">
                Reset
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
import axios from "axios";
import Alert from "./Alert.vue";
const action_C = "add";
  // const action_R = "get";
  const action_U = "upd";
  // const action_D = "del";
const hostname = "http://localhost:5001/"

export default {  
  data() {
    return {
      activeAddModal: false,
      activeUpdateModal: false,
      memberForm: {
        id: "",
        username: "",
        age: "",
        salary: "",
        department: "",
        sex: '',
        email: "",
        password: ""
      },
      members: [],
      message: "",
      showMessage: false,
      action: ""
    };
  },
  components: {
    alert: Alert,
  },
  methods: {
    toggleAddMemberModal() {
      const body = document.querySelector("body");
      this.activeAddModal = !this.activeAddModal;
      if (this.activeAddModal) {
        body.classList.add("modal-open");
        this.action = action_C;
      } else {
        body.classList.remove("modal-open");
        this.action = "";
      }
    },
    toggleEditMemberModal(Member) {      
      if (Member) {
        this.memberForm = Member;
      }
      const body = document.querySelector("body");
      this.activeUpdateModal = !this.activeUpdateModal;
      if (this.activeUpdateModal) {
        body.classList.add("modal-open");
        this.action = action_U;
      } else {
        body.classList.remove("modal-open");
        this.action = "";
      }
    },
    handleCloseModal(){
      if (this.action == action_C){
        this.toggleAddMemberModal();
      }else if (this.action == action_U){
        this.toggleEditMemberModal();
      }
    },
    initForm() {
      this.memberForm.id="";
      this.memberForm.username="";
      this.memberForm.age="";
      this.memberForm.salary="";
      this.memberForm.department="";
      this.memberForm.sex='';
      this.memberForm.email="";
      this.memberForm.password="";
    },
    handleSubmit() {
      switch (this.action) {
        case action_C:
          this.toggleAddMemberModal();
          this.addMember(this.memberForm);
          this.initForm();
          break;
        case action_U:
          this.toggleEditMemberModal(null);
          this.updateMember(this.memberForm);
          break;
        default:
          break;
      }
    },
    handleReset() {
      switch (this.action) {
        case action_C:
          this.initForm();
          break;
        case action_U:
          this.toggleEditMemberModal(null);
          this.initForm();
          this.getMembers(); // why?
          break;
        default:
          break;
      }
    },
    handleDeleteClick(Member) {
      this.removeMember(Member.id);
    },
    // CRUD member
    addMember(payload) {
      const path = hostname+"Account/empl/add";
      axios.post(path, payload)
          .then(() => {
            this.getMembers();
            this.message = "Member added";
            this.showMessage = true;
          })
          .catch((error) => {
            console.log(error);
            this.getMembers();
          });
    },
    getMembers() {
      // var ann = {
      //       id:"df7fd05c-bc6c-4dcf-9028-991d1deb5c08",
      //       username:"Ann",
      //       age:"23",
      //       salary:"3.00",
      //       department:"HR",
      //       sex:'F',
      //       email:"a@bc.de",
      //       password:"P@ssw0rd"
      //     };
      // this.members = [ann];//for test

      const path =hostname+"Account/empl/get";
      axios.get(path)
          .then((res) => {
            this.members = res.data;
          })
          .catch((error) => {
            console.error(error);
          });
      console.log("getMembers done");
    },
    updateMember(payload) {

      const path = hostname + "Account/empl/upd";
      axios.put(path, payload)
          .then(() => {
            this.getMembers();
            this.message = 'Member updated!';
            this.showMessage = true;
          })
          .catch((error) => {
            console.error(error);
            this.getMembers();
          });
    },
    removeMember(MemberID) {
      //var heads={ crossDomain: true, "Content-Type": "application/json" }
      const path = hostname + "Account/empl/del/" + MemberID;
      axios.delete(path)//,{headers:heads})
          .then(() => {
            this.message = 'Member removed!';
            this.showMessage = true;
            this.getMembers();
          })
          .catch((error) => {
            console.error(error);
            this.getMembers();
          });
    },

  },
  created() {
    // console.log("component: 'Members' created!");//for test
    this.getMembers();
  },
};
</script>
