const drawProducts = (products) => {
    const template = document.getElementById('temp-card');
    document.getElementById('ItemsCountText').innerHTML = JSON.parse(sessionStorage.getItem('itemsCount')) || 0;
    products.forEach((product) => {
        const clone = template.content.cloneNode(true);

        clone.querySelector('img').src = product.imageUrl;
        clone.querySelector('h1').textContent = product.productName;
        clone.querySelector('.price').textContent = product.price;
        clone.querySelector('.description').textContent = product.description;

        clone.querySelector('button').addEventListener('click', () => {
            updateProductInStorage(product);
        });

        document.getElementById('PoductList').appendChild(clone);
    });
}
var conditionMet = false
const getAllProducts = async () => {

    try {
        const response = await fetch('api/Product')

        if (!response.ok) {
            throw new Error(`error! status:${response.status}`)
        }
        else {
            const data = await response.json()
            console.log(data)
            drawProducts(data)
        }
    }
    catch (error) {
        console.error(error)
    }

}

function updateProductInStorage(prod) {
    /////basket handling
    const basket = JSON.parse(sessionStorage.getItem('basket')) || [];
 
    const productIndex = basket.findIndex(product => product.productId === prod.productId);
    console.log(productIndex)
    if (productIndex !== -1) {
        basket[productIndex].quaninty+=1;
    } else {
        prod = { ...prod, quaninty: 1 }
        basket.push(prod);
    }
    sessionStorage.setItem('basket', JSON.stringify(basket));
    //////////

    const itemsCount = JSON.parse(sessionStorage.getItem('itemsCount')) || 0;
    sessionStorage.setItem("itemsCount", itemsCount + 1)
    document.getElementById('ItemsCountText').innerHTML = itemsCount+1;

 
    conditionMet = true
  updateSum(prod)
}
const updateSum = (prod) => {
    const cartSum = sessionStorage.getItem('cartSum')||0
    const currentProductPrice = prod.price;
    const newSum = 1* cartSum + currentProductPrice;
    sessionStorage.setItem("cartSum", newSum);
   // document.getElementById('price').textContent = newSum;
}
//const updateCount = () => {
//    const itemsCount = sessionStorage.getItem('itemsCount')
//    itemsCount += 1;
//}

const addOrder = async () => {
    const order = {
        orderSum: document.getElementById("sum").value,
        userId: JSON.parse(sessionStorage.getItem('user')).userId

    }
    const response = await fetch("api/order", {

        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    });
    const data = await response.json()

    if (response.ok == false) {

        throw new Error(`error! status:${response.status}`)
    }
    else {
        alert("add order")
        sessionStorage.setItem('basket', [])
        return data.orderId
    }
}

getAllProducts()