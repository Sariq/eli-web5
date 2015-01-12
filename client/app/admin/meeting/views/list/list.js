(function () {
  function MeetingListController(MeetingAdmin,$stateParams) {
    var self = this;
    console.log(MeetingAdmin);
    self.meetings = MeetingAdmin.listMeetings();
                        
  
 
     self.remove = function (meeting) {
        console.log(meeting);
        console.log(meeting._id);
        alert(meeting._id)
        meeting.$remove({_id: meeting._id}, function () {
          self.meetings = MeetingAdmin.query();
        });
      };
  }

  angular.module('eli.admin')
    .controller('MeetingListController', ['MeetingAdmin','$stateParams',MeetingListController]);
}());
















