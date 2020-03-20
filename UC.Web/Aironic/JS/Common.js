function AdjustColumnsHeight()
{
    // get a reference to the three DIVS that make up the columns
    var centerCol = window.document.getElementById('centercol');
    var leftCol = window.document.getElementById('leftcol');
    var rightCol = window.document.getElementById('rightcol');
    // calculate the max height
    var hCenterCol = centerCol.offsetHeight;
    var hLeftCol = leftCol.offsetHeight;
    var hRightCol = rightCol.offsetHeight;
    var maxHeight = Math.max(hCenterCol, Math.max(hLeftCol, hRightCol));
    var clientHeight
    //Определение высоты активной области браузера
    if (self.innerHeight) 
    {clientHeight = self.innerHeight;
    if (maxHeight+200 < clientHeight){maxHeight = clientHeight-217};}
    // IE 6 Strict Mode	
    else if (document.documentElement && document.documentElement.clientHeight)
    {clientHeight = document.documentElement.clientHeight;
    if (maxHeight+200 < clientHeight){maxHeight = clientHeight-217};}
    // Остальные версии IE	
    else if (document.body)
    {clientHeight = document.body.clientHeight;
    if (maxHeight+200 < clientHeight){maxHeight = clientHeight-237};}            
    // set the height of all 3 DIVS to the max height
    centerCol.style.height = maxHeight + 'px';
    leftCol.style.height = maxHeight + 'px';
    rightCol.style.height = maxHeight + 'px';            
    // Show the footer
    window.document.getElementById('footer').style.visibility = 'inherit';
}

