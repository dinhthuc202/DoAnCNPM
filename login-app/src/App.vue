<script>
export default{
  data(){
    return{
      count: 2,
      username: "hoc",
    };
  },

  methods:{
    congLenMot(){
      this.count++;
    },
    truDiMot(){
      this.count--;
    },
  },

  computed:{
    countMaCongThemMot(){
      return this.count+1;
    },
  },
};
</script>

<template>
  <button :disabled="count < 1" @click="truDiMot0">

  </button>

  <h1 ></h1>
</template>