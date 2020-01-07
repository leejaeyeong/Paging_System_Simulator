## Paging_System_Simulator

### 주요 가정
 - 각 PMT의 page number는 1번부터 시작.
 - 메인 메모리는 100개의 페이지 프레임으로 구성.
 -  A, B, C, D 프로세스가 존재하고 각 프로세스 마다 페이지의 개수를 설정할 수 있음.
 - 프로세스의 페이지가 메인 메모리에 할당 되고 있을 때 다른 프로세스가 동작 될 
   경우 각각의 프로세스의 페이지는 교차적으로 메인 메모리에 적재되도록 구현.

### Test case
|Process|Page quantity|Color|
|------|---|----|
|A|26|RED|
|B|8|YELLOW|
|C|19|BLUE|
|D|24|EMERALD|  

### 실행  
<div align="center">
  <table align="center" border="0" >
  <tr>
    <td> <img src="https://github.com/leejaeyeong/Paging_System_Simulator/blob/master/images/noname01.png" width="800" height="auto">
   </td>
   <td> <img src="https://github.com/leejaeyeong/Paging_System_Simulator/blob/master/images/noname02.png" width="800" height="auto"></td>
  </tr>
  <tr>
    <td>프로세스 실행 전. 프로세스 A, B, C, D와 메모리 현황 </td>
   <td>A 프로세스만 실행. 순차적으로 메모리에 페이지가 적재됨 </td>
  </tr>
  <tr>
    <td> <img src="https://github.com/leejaeyeong/Paging_System_Simulator/blob/master/images/noname03.png" width="800" height="auto"></td>
   <td> <img src="https://github.com/leejaeyeong/Paging_System_Simulator/blob/master/images/noname04.png" width="800" height="auto"></td>
  </tr>
   <tr>
    <td>A 프로세스 실행 중 B 프로세스가 실행될 경우 각 프로세스를 교차하여 적재(비연속적) </td>
     <td>프로세스 A,B,C,D가 메모리에 모두 적재됨 </td>
  </tr>

  
</table>
  </div>
