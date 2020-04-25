<template>
    <div v-if="loggedIn" class="main-container">
        <Navbar
            :username="username"
            :selectedTab="selectedTab"
            @globalSearch="globalSearch"
            @showTheCart="showTheCart"
        />
        <Filters :selectedFilters="filters" @selectFilters="selectFilters"/>
        <LoadingSpinner v-if="isLoading"/>
        <Products v-else @addToCart="addToCart"/>
        <MyCart 
            v-if="showCart"
            :shopCartData="shopCartData"
            @closeTheCart="closeTheCart"
        />
    </div>
    <div v-else class="main-container">
        <Login @login="login"/>
    </div>
</template>

<script>
    import Navbar from './Navbar.vue'
    import LoadingSpinner from './LoadingSpinner.vue'
    import Filters from './Filters.vue'
    import Products from './Products.vue'
    import Login from './Login.vue'
    import MyCart from './MyCart.vue'
    import JQuery from 'jquery'
    let $ = JQuery
    export default {
        components: {
            Navbar,
            LoadingSpinner,
            Filters,
            Products,
            Login,
            MyCart
        },

        created() {
            // eslint-disable-next-line no-console
            this.loggedIn = true
        },

        props: {
            csrftoken: {
                type: String,
                default: ''
            },
        },

        data: () => {
            return {
                selectedTab: 2,
                isLoading: false,
                filters: {
                    minPrice: 0,
                    maxPrice: 99999,
                    available: false,
                    isInternational: false
                },
                username: '',
                userId: 0,
                countryId: 0,
                loggedIn: false,
                globalSearchName: '',
                showCart: false,
                shopCartData: [],
            }
        },

        computed: {

        },
        
        methods: {
            selectTab(index) {
                this.status = 0
                this.editDocument = false
                this.selectedDocument = {}
                this.$forceUpdate()
                if (!this.isLoading) {
                    this.selectedTab = index
                    this.isLoading = true
                    if (this.selectedTab == 2) {
                        this.getDocuments()
                    }
                    if (this.selectedTab == 3) {
                        this.selectedDocument = {}
                        setTimeout(() => {
                            this.isLoading = false
                        }, 200)
                    }
                    if (this.selectedTab == 1) {
                        this.attemptLogout()
                    }
                }
            },

            showTheCart() {
                if (this.shopCartData.length > 0) this.showCart = true
            },

            closeTheCart() {
                this.showCart = false
            },

            addToCart(product) {
                this.shopCartData.push(product)
            },

            selectFilters(f) {
                this.filters = f
                if (!this.isLoading) {
                    this.isLoading = true
                    setTimeout(() => {this.isLoading = false},1000)
                }
            },

            globalSearch(name) {
                this.globalSearchName = name
                if (!this.isLoading) {
                    this.isLoading = true
                    setTimeout(() => {this.isLoading = false},1000)
                }
            },

            login(data) {
                // eslint-disable-next-line no-console
                console.log(data)
                $.get("http://localhost:5000/User/login", {Username : data.username, Password : data.password}, response =>{
                    if(response.FirstName){
                        this.username = response.FirstName + ' ' + response.LastName
                        this.countryId = response.CountryId
                        this.loggedIn = true
                    }
                })
            },
        },
    }
</script>

<style scoped>
    .main-container {
        background: #b6bec8;
        font-family: 'Roboto', sans-serif;
        height: 100vh;
        width: 100%;
        position: relative;
        display: flex;
    }
    .main-container #error, .main-container #passError, .main-container #codeError {
        min-width: 250px;
        margin-left: -125px;
        background-color: #ed2c25;
        text-align: center;
        border-radius: 2px;
        padding: 16px;
        position: absolute;
        z-index: 1;
        top: 10px;
        right: 10px;
        -webkit-animation: fadein 0.5s, fadeout 0.5s 2.5s;
        animation: fadein 0.5s, fadeout 0.5s 2.5s;
        animation-fill-mode: forwards;
        display: flex;
        justify-content: center;
        align-items: center;
        flex-direction: column;
        cursor: default;
    }
    .main-container #error:hover,
    .main-container #passError:hover, 
    .main-container #codeError:hover {
        -webkit-animation: fadein 0.5s;
        animation: fadein 0.5s;
        animation-fill-mode: none;
    }
    .main-container #error span,
    .main-container #passError span, 
    .main-container #codeError span {
        color: #fff;
        padding: 5px;
    }
    @-webkit-keyframes fadein {
        from {top: 0; opacity: 0;} 
        to {top: 10px; opacity: 1;}
    }
    @keyframes fadein {
        from {top: 0; opacity: 0;}
        to {top: 10px; opacity: 1;}
    }
    @-webkit-keyframes fadeout {
        from {top: 10px; opacity: 1;} 
        to {top: 0; opacity: 0;}
    }
    @keyframes fadeout {
        from {top: 10px; opacity: 1;}
        to {top: 0; opacity: 0;}
    }
</style>