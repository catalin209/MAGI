<template>
    <div class="products-container">
        <div class="product-container" v-for="product in products" :key="product.id">
            <img :src="`/product-${product.id}.png`"/>
            <span class="name">{{`${product.id} - ${product.name}`}}</span>
            <span class="price">{{product.price}}&#x24;</span>
            <button class="btn" @click="addToCart(product)">Add to cart <i class="cart"/></button>
        </div>
    </div>
</template>

<script>
    export default {
        // props: {
        //     products: {
        //         type: Array
        //     },
        // },

        data: () => {
            return {
                products: [
                    {
                        id: 1,
                        name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                        price: 100
                    },
                    {
                        id: 2,
                        name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                        price: 200
                    },
                    {
                        id: 3,
                        name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                        price: 300
                    },
                    {
                        id: 4,
                        name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                        price: 400
                    },
                    {
                        id: 5,
                        name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                        price: 500
                    },
                    {
                        id: 6,
                        name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                        price: 600
                    },
                    {
                        id: 7,
                        name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                        price: 700
                    },
                    {
                        id: 8,
                        name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                        price: 800
                    },
                ],
            }
        },

        methods: {
            addToCart(product) {
                this.$emit('addToCart', product)
            },
        },
    }
</script>

<style scoped>
    .products-container {
        flex: 7;
        display: flex;
        justify-content: flex-start;
        align-items: flex-start;
        flex-wrap: wrap;
        margin: 100px 50px 0px 0px;
        overflow: auto;
        height: calc(100vh - 150px);
    }
    .product-container {
        width: calc(100% / 6 - 30px);
        margin-right: 30px;
        background: #fff;
        -webkit-box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        -moz-box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        display: flex;
        justify-content: center;
        align-items: center;
        flex-direction: column;
        height: 400px;
        overflow: hidden;
        position: relative;
        margin-bottom: 30px;
        padding-top: 30px;
    }
    .product-container img {
        width: 100px;
        height: 100px;
        margin-bottom: 30px;
    }
    .product-container .name {
        font-weight: 700;
        font-size: 16px;
        display: block;
        text-overflow: ellipsis;
        word-wrap: break-word;
        overflow: hidden;
        max-height: 60px;
        line-height: 20px;
        width: calc(100% - 20px);
        padding: 0px 10px;
        margin-bottom: 30px;
    }
    .product-container .price {
        font-weight: 700;
        font-size: 24px;
        color: #41b883;
        margin-bottom: 30px;
    }
    .product-container .btn {
        display: inline-flex;
        margin-bottom: 0;
        font-weight: 700;
        text-align: center;
        white-space: nowrap;
        vertical-align: middle;
        -ms-touch-action: manipulation;
        touch-action: manipulation;
        cursor: pointer;
        background-image: none;
        border: 1px solid transparent;
        font-size: 14px;
        line-height: 1.42857143;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
        color: #333;
        background-color: #d3d3d3;
        border-color: #ddd;
        padding: 10px;
    }
    .product-container .btn .cart {
        background: url('../assets/shopping-cart.png') center no-repeat;
        width: 24px;
        height: 24px;
        margin-left: 5px;
        margin-top: -2px;
    }
</style>