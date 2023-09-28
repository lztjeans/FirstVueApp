<script setup>
import { useSlots } from 'vue'
const props = defineProps({
  tableHeads: {
    type: Array,
    required: true,
  },
  tableBody: {
    type: Array,
    required: true,
  },
})

const slots = useSlots()
console.log(`slots`, slots)




</script>

<template>
  <table>
    <thead>
      <th></th>
      <th v-for="tableHead in props.tableHeads" :key="tableHead">
        {{ tableHead }}
      </th>
    </thead>
    <tbody>
      <tr v-for="(item, itemIndex) in props.tableBody" :key="item.name">
        <td>{{ itemIndex + 1 }}</td>
        <td v-for="(value, key, index) in item" :key="value">
          <span v-if="!Object.keys($slots).includes(key)" v-show="itemIndex==0">{{ value }}</span>
          <slot v-else :name="key " :value="value" :index="itemIndex" ></slot>
        </td>
      </tr>
    </tbody>
  </table>
</template>
<!--

    :props="props"
-->