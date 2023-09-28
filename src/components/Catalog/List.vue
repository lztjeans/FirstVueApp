<template>
    <MyTable :tableHeads="tableHeads" :tableBody="tableBody">
      <template #ithelpLink="{ index, props, value }">
            <button type="button" @click="handleClick('u',value)">Update</button>
      </template>
      <template #deleteLink="{index, props, value }">
        <button type="button" @click="handleClick('d',value)">Delete</button>
      </template>
    </MyTable>
  </template>

<script setup>
//import MyTable from './components/MyTable.vue'
import MyTable from '../shared/Mytable.vue';
//, 'Delete'
const tableHeads = ['Id', 'Name', 'Description', 'Price', 'Picture', 'Type Name', 'Brand', 'Update', 'Delete']
// const tableBody = [
// {
//     id: "16",
//     name: '阿傑',
//     description: '咩色用得好，歸剛沒煩惱',
//     price: '從 ECMAScript 偷窺 JavaScript Array method',
//     pic: 'this is a icon',
//     typename: 'tv',
//     brand: 'Sony',
//     ithelpLink: '/users/20152459/ironman/5744',
//     deleteLink: '/users/20151114/ironman/5425',
//   }
// ]
</script>

<script>
import axios from "axios";

export default {  
    data() {
        return {
            tableBody: [],
            bodyData: {
                
                name: 'abc',
                description: 'desc',
                price: '1',
                pic: '33',
                typename: '123',
                brand: 'e1f',
                updateLink: '2',
                deleteLink: '3',
            },
        }
    },
    methods: {
        handleClick(action, val){
            switch(action){
                case 'u':
                    alert("Update this item now... redir :" + val)
                    break;
                case 'd':
                    alert("This item was deleted by " + val);
                    break;
            }
        },
        getAllProducts(){
            this.tableBody[this.bodyData];
            // const path = "http://localhost:5001/prod/get";
        //     axios.get(path)
        //         .then((res) => {
        //             console.log(res.data);
        //         })
        //         .catch((error) => {
        //             console.error(error);
        //         });
        // },

    },
    created(){
        this.getAllProducts();

    },
}
}
</script>


<style>
table,
th,
td {
  border: 1px solid;
}

tr,
th {
  padding: 5px;
}
</style>