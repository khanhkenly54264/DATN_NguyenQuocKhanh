// chatData.js
const chatData = {
    currentCustomerId: null,
    currentAdminId: 'admin01',
    conversations: {
        'cust001': {
            customerName: 'Khách hàng 1',
            messages: [
                {
                    sender: 'admin01',
                    content: 'Xin chào! Chúng tôi có thể giúp gì cho bạn?',
                    time: '10:30 AM'
                },
                {
                    sender: 'cust001',
                    content: 'Tôi cần hỗ trợ về sản phẩm.',
                    time: '10:32 AM'
                }
            ]
        },
        'cust002': {
            customerName: 'Khách hàng jvckl',
            messages: [
                {
                    sender: 'admin01',
                    content: 'Chào bạn, bạn cần giúp gì?',
                    time: '10:35 AM'
                },
                {
                    sender: 'cust002',
                    content: 'sadasdas',
                    time: '11:31'
                }
            ]
        }
    }
};

function getChatData() {
    return chatData;
}

function addMessage(customerId, message, sender) {
    const now = new Date();
    const timeString = now.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
    if (!chatData.conversations[customerId]) {
        chatData.conversations[customerId] = {
            customerName: 'Khách hàng ' + customerId.substr(4),
            messages: []
        };
    }
    chatData.conversations[customerId].messages.push({
        sender: sender,
        content: message,
        time: timeString
    });
}