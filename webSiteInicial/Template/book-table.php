<?php
$book_tn=$_POST['booking_table_no'];
$book_date=$_POST['booking_date'];
$book_fname=$_POST['booking_fname'];
$book_lname=$_POST['booking_lname'];
$book_guest=$_POST['booking_guest'];
$book_female=$_POST['booking_female'];
$book_male=$_POST['booking_male'];
$book_mail=$_POST['booking_mail'];
$book_phone=$_POST['booking_phone'];
$book_instruction=$_POST['booking_instruction'];

if(trim($book_tn)!="Your Table Number" && trim($book_date)!="Your Booking Date" && trim($book_fname)!="Your First Name" && trim($book_lname)!="Your Last Name" && trim($book_guest)!="Number Of Guest" && trim($book_female)!="Female" && trim($book_male)!="Male" && trim($book_mail)!="Your Email Id" && trim($book_phone)!="Your Phone No" && trim($book_instruction)!="Message" && trim($book_tn)!="" && trim($book_date)!="" && trim($book_fname)!="" && trim($book_lname)!="" && trim($book_guest)!="" && trim($book_female)!="" && trim($book_male)!="" && trim($book_mail)!="" && trim($book_phone)!="" && trim($book_instruction)!="") 
{
	if(filter_var($book_mail, FILTER_VALIDATE_EMAIL))
	{
		$message="Hi Admin..
		<p>".$book_fname." ".$book_lname." has booked Rockon Table...</p>
		<p>Table No.        : ".$book_tn."</p>
		<p>Date             : ".$book_date."</p>
		<p>No Of Guest      : ".$book_guest."</p>
		<p>Female           : ".$book_female."</p>
		<p>Male             : ".$book_male."</p>
		<p>Phone No         : ".$book_phone."</p>
		<p>Mail Id          : ".$book_mail."</p>
		<p>Message          : ".$book_instruction."</p>";
		
		$message_user="Hi ".$book_fname." ".$book_lname."<p> Thank you so much for Booking with Rockon Club.</p><p>Have a rocking day ahead.</p>";
		
		
		$headers = "MIME-Version: 1.0" . "\r\n";
		$headers .= "Content-type:text/html;charset=UTF-8" . "\r\n";
		$headers .= 'From: <support@himanshusofttech.com>' . "\r\n";

		if(mail('support@himanshusofttech.com','Rockon Booking',$message,$headers ))
		{
		mail($book_mail,'Reply from Rockon Template Team',$message_user,$headers );
			
		echo '1#<p style="color:green;">Mail has been sent successfully.</p>';
		}
		else
		{
		echo '2#<p style="color:red;">Please, Try Again.</p>';
		}
	}
	else
		echo '2#<p style="color:red">Please, provide valid Email.</p>';
}
else
{
echo '2#<p style="color:red">Please, fill all the details.</p>';
}?>