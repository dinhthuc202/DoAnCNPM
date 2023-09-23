const array1 = [1, 2, 3, 4, 5];
const array2 = [2, 3, 4, 5, 6];

const commonElements = [];

//Duyệt từng phần tử arr 1 tương ứng với element
for (const element of array1) {
    //Dùng includes để xem có tồn tại element trong đó không
  if (array2.includes(element)) {
    commonElements.push(element);
    if (commonElements.length>2) {
        
    }
  }
}

console.log(commonElements);